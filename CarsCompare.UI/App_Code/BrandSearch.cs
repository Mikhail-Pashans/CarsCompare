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
    public class BrandSearch
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;
        private readonly LogWriter _logWriter;

        public BrandSearch(IUnitOfWork unitOfWork, ICacheService cache, LogWriter logWriter)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logWriter = logWriter;
        }

        public async Task<IEnumerable<BrandViewModel>> GetBrands()
        {
            IQueryable<BrandModel> brands = _cache.Get<IQueryable<BrandModel>>("brands");

            if (brands == null)
            {
                var brandBo = new BrandBO(_unitOfWork);
                ExceptionDispatchInfo capturedException = null;

                try
                {
                    var brandModels = await brandBo.GetBrands();
                    brands = brandModels.AsQueryable();
                    _cache.Set("brands", brands, 15);
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

            var brandViewModels = brands.Select(BrandViewModel.Map);

            return brandViewModels;
        }
    }
}