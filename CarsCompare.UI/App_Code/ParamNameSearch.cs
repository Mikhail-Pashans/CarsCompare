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
                var paramNameBo = new ParamNameBO(_unitOfWork);
                ExceptionDispatchInfo capturedException = null;

                try
                {
                    var paramNameModels = await paramNameBo.GetParamNames();
                    paramNames = paramNameModels.AsQueryable();
                    _cache.Set("paramNames", paramNames, 15);
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

            var paramNameViewModels = paramNames.Select(ParamNameViewModel.Map);

            return paramNameViewModels;
        }
    }
}