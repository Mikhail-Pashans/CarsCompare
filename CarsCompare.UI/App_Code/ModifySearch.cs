﻿using CarsCompare.Database;
using CarsCompare.Domain.BusinessObjects;
using CarsCompare.Domain.Models;
using CarsCompare.Logger;
using CarsCompare.UI.Cache;
using CarsCompare.UI.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsCompare.UI
{
    public class ModifySearch
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;
        private readonly LogWriter _logWriter;

        public ModifySearch(IUnitOfWork unitOfWork, ICacheService cache, LogWriter logWriter)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logWriter = logWriter;
        }

        public async Task<IEnumerable<ModifyViewModel>> GetModifies()
        {
            IQueryable<ModifyModel> modifies = _cache.Get<IQueryable<ModifyModel>>("modifies");

            if (modifies == null)
            {
                var modifyBo = new ModifyBO(_unitOfWork);
                var modelModels = await modifyBo.GetModifies();
                modifies = modelModels.AsQueryable();
                _cache.Set("modifies", modifies, 10);
            }

            var modifyViewModels = modifies.Select(ModifyViewModel.Map);

            return modifyViewModels;
        }

        public async Task<IEnumerable<ModifyViewModel>> GetModifiesByModelIdAndVersionId(int modelId, int versionId)
        {
            IQueryable<ModifyModel> modifies = _cache.Get<IQueryable<ModifyModel>>(string.Format("modifies-{0}-{1}", modelId, versionId));

            if (modifies == null)
            {
                var modifyBo = new ModifyBO(_unitOfWork);
                var modelModels = await modifyBo.GetModifiesByModelIdAndVersionId(modelId, versionId);
                modifies = modelModels.AsQueryable();
                _cache.Set(string.Format("modifies-{0}-{1}", modelId, versionId), modifies, 10);
            }

            var modifyViewModels = modifies.Select(ModifyViewModel.Map);

            return modifyViewModels;
        }
    }
}