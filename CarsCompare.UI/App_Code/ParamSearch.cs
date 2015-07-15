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
    public class ParamSearch
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cache;
        private readonly LogWriter _logWriter;

        public ParamSearch(IUnitOfWork unitOfWork, ICacheService cache, LogWriter logWriter)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logWriter = logWriter;
        }

        public async Task<IEnumerable<ParamViewModel>> GetParams()
        {
            IQueryable<ParamModel> parameters = _cache.Get<IQueryable<ParamModel>>("params");

            if (parameters == null)
            {
                var paramBo = new ParamBO(_unitOfWork);
                ExceptionDispatchInfo capturedException = null;

                try
                {
                    var paramModels = await paramBo.GetParams();
                    parameters = paramModels.AsQueryable();
                    _cache.Set("params", parameters, 15);
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

            var paramViewModels = parameters.Select(ParamViewModel.Map);

            return paramViewModels;
        }

        public async Task<IEnumerable<ParamViewModel>> GetParamsByModifyId(int modifyId)
        {
            IQueryable<ParamModel> parameters = _cache.Get<IQueryable<ParamModel>>(string.Format("params-{0}", modifyId));

            if (parameters == null)
            {
                var paramBo = new ParamBO(_unitOfWork);
                ExceptionDispatchInfo capturedException = null;

                try
                {
                    var paramModels = await paramBo.GetParamsByModifyId(modifyId);
                    parameters = paramModels.AsQueryable();
                    _cache.Set(string.Format("params-{0}", modifyId), parameters, 15);
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

            var paramViewModels = parameters.Select(ParamViewModel.Map);

            return paramViewModels;
        }
    }
}