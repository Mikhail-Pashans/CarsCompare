using CarsCompare.Database;
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
                var paramModels = await paramBo.GetParams();
                parameters = paramModels.AsQueryable();
                _cache.Set("params", parameters, 10);
            }

            var paramViewModels = parameters.Select(ParamViewModel.Map);

            return paramViewModels;
        }
    }
}