using CarsCompare.Database;
using CarsCompare.Domain.BusinessObjects;
using CarsCompare.Domain.Models;
using CarsCompare.Logger;
using CarsCompare.UI.Cache;
using CarsCompare.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsCompare.UI
{
    public class ModelSearch
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;
        private readonly LogWriter _logWriter;

        public ModelSearch(IUnitOfWork unitOfWork, ICacheService cache, LogWriter logWriter)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logWriter = logWriter;
        }

        public async Task<IEnumerable<ModelViewModel>> GetModels()
        {
            IQueryable<ModelModel> models = _cache.Get<IQueryable<ModelModel>>("models");

            if (models == null)
            {
                try
                {
                    var modelBo = new ModelBO(_unitOfWork);
                    var modelModels = await modelBo.GetModels();
                    models = modelModels.AsQueryable();
                    _cache.Set("models", models, 15);
                }
                catch (Exception ex)
                {
                    _logWriter.WriteError(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                    throw;
                }
            }

            var modelViewModels = models.Select(ModelViewModel.Map);

            return modelViewModels;
        }

        public async Task<IEnumerable<ModelViewModel>> GetModelsByBrandId(int brandId)
        {
            IQueryable<ModelModel> models = _cache.Get<IQueryable<ModelModel>>(string.Format("models-{0}", brandId));

            if (models == null)
            {
                try
                {
                    var modelBo = new ModelBO(_unitOfWork);
                    var modelModels = await modelBo.GetModelsByBrandId(brandId);
                    models = modelModels.AsQueryable();
                    _cache.Set(string.Format("models-{0}", brandId), models, 15);
                }
                catch (Exception ex)
                {
                    _logWriter.WriteError(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                    throw;
                }
            }

            var modelViewModels = models.Select(ModelViewModel.Map);

            return modelViewModels;
        }
    }
}