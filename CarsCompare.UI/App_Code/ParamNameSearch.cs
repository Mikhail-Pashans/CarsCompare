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
    public class ParamNameSearch
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;
        private readonly LogWriter _logWriter;

        public ParamNameSearch(IUnitOfWork unitOfWork, ICacheService cache, LogWriter logWriter)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logWriter = logWriter;
        }

        public async Task<IEnumerable<ParamNameViewModel>> GetParamNames()
        {
            IQueryable<ParamNameModel> paramNames = _cache.Get<IQueryable<ParamNameModel>>("paramNames");

            if (paramNames == null)
            {
                try
                {
                    var paramNameBo = new ParamNameBO(_unitOfWork);
                    var paramNameModels = await paramNameBo.GetParamNames();
                    paramNames = paramNameModels.AsQueryable();
                    _cache.Set("paramNames", paramNames, 15);
                }
                catch (Exception ex)
                {
                    _logWriter.WriteError(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                    throw;
                }
            }

            var paramNameViewModels = paramNames.Select(ParamNameViewModel.Map);

            return paramNameViewModels;
        }
    }
}