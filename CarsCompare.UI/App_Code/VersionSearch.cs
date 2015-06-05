using CarsCompare.Database;
using CarsCompare.Domain.BusinessObjects;
using CarsCompare.Domain.Models;
using CarsCompare.Logger;
using CarsCompare.UI.Cache;
using CarsCompare.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace CarsCompare.UI
{
    public class VersionSearch
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;
        private readonly LogWriter _logWriter;

        public VersionSearch(IUnitOfWork unitOfWork, ICacheService cache, LogWriter logWriter)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logWriter = logWriter;
        }

        public async Task<IEnumerable<VersionViewModel>> GetVersions()
        {
            IQueryable<VersionModel> versions = _cache.Get<IQueryable<VersionModel>>("versions");

            if (versions == null)
            {
                var versionBo = new VersionBO(_unitOfWork);
                ExceptionDispatchInfo capturedException = null;

                try
                {
                    var versionModels = await versionBo.GetVersions();
                    versions = versionModels.AsQueryable();
                    _cache.Set("versions", versions, 15);
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

            var versionViewModels = versions.Select(VersionViewModel.Map);

            return versionViewModels;
        }

        public async Task<IEnumerable<VersionViewModel>> GetVersionsByModelId(int modelId)
        {
            IQueryable<VersionModel> versions =
                _cache.Get<IQueryable<VersionModel>>(string.Format("versions-{0}", modelId));

            if (versions == null)
            {
                var versionBo = new VersionBO(_unitOfWork);
                ExceptionDispatchInfo capturedException = null;

                try
                {
                    var versionModels = await versionBo.GetVersionsByModelId(modelId);
                    versions = versionModels.AsQueryable();
                    _cache.Set(string.Format("versions-{0}", modelId), versions, 15);
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

            var versionViewModels = versions.Select(VersionViewModel.Map);

            return versionViewModels;
        }
    }
}