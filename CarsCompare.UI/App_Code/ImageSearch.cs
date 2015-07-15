using CarsCompare.Logger;
using CarsCompare.UI.Cache;
using CarsCompare.UI.ViewModels;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace CarsCompare.UI
{
    public class ImageSearch
    {
        private readonly ICacheService _cache;
        private readonly LogWriter _logWriter;

        public ImageSearch(ICacheService cache, LogWriter logWriter)
        {
            _cache = cache;
            _logWriter = logWriter;
        }

        public async Task<string> GetImageAsync(CarViewModel viewModel)
        {
            string imageUrl =
                _cache.Get<string>(string.Format("imageUrl-{0}-{1}-{2}", viewModel.BrandId, viewModel.ModelId,
                    viewModel.VersionId));

            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                var server = ConfigurationManager.AppSettings.Get("Server");
                ExceptionDispatchInfo capturedException = null;

                try
                {
                    imageUrl = await Task.Run(() => Directory.EnumerateFiles(string.Format(@"{0}\CarsImages", server),
                        string.Format("{0}_{1}_{2}_*", viewModel.BrandId, viewModel.ModelId,
                            viewModel.VersionId), SearchOption.TopDirectoryOnly).FirstOrDefault());

                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        imageUrl = imageUrl.Replace(string.Format("{0}", server), string.Empty);
                        _cache.Set(
                            string.Format("imageUrl-{0}-{1}-{2}", viewModel.BrandId, viewModel.ModelId, viewModel.VersionId),
                            imageUrl, 15);
                    }
                    else
                    {
                        imageUrl = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    capturedException = ExceptionDispatchInfo.Capture(ex);
                }

                if (capturedException != null)
                {
                    await _logWriter.WriteErrorAsync(capturedException.SourceException.InnerException != null
                        ? capturedException.SourceException.InnerException.Message
                        : capturedException.SourceException.Message);

                    capturedException.Throw();
                }
            }

            return imageUrl;
        }
    }
}