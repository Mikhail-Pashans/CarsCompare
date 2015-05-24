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
    public class ParamGroupSearch
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;
        private readonly LogWriter _logWriter;

        public ParamGroupSearch(IUnitOfWork unitOfWork, ICacheService cache, LogWriter logWriter)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logWriter = logWriter;
        }

        public async Task<IEnumerable<ParamGroupViewModel>> GetParamGroups()
        {
            IQueryable<ParamGroupModel> paramGroups = _cache.Get<IQueryable<ParamGroupModel>>("paramGroups");

            if (paramGroups == null)
            {
                try
                {
                    var paramGroupBo = new ParamGroupBO(_unitOfWork);
                    var paramGroupModels = await paramGroupBo.GetParamGroups();
                    paramGroups = paramGroupModels.AsQueryable();
                    _cache.Set("paramGroups", paramGroups, 15);
                }
                catch (Exception ex)
                {
                    _logWriter.WriteError(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                    throw;
                }
            }

            var paramGroupViewModels = paramGroups.Select(ParamGroupViewModel.Map);

            return paramGroupViewModels;
        }

        public async Task<IEnumerable<ParamGroupViewModel>> GetParamGroupsWithParamNames()
        {
            IQueryable<ParamGroupModel> paramGroups = _cache.Get<IQueryable<ParamGroupModel>>("paramGroupsWithParamNames");

            if (paramGroups == null)
            {
                try
                {
                    var paramGroupBo = new ParamGroupBO(_unitOfWork);
                    var paramGroupModels = await paramGroupBo.GetParamGroupsWithParamNames();
                    paramGroups = paramGroupModels.AsQueryable();
                    _cache.Set("paramGroupsWithParamNames", paramGroups, 15);
                }
                catch (Exception ex)
                {
                    _logWriter.WriteError(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                    throw;
                }
            }

            var paramGroupViewModels = paramGroups.Select(ParamGroupViewModel.Map);

            return paramGroupViewModels;
        }
    }
}