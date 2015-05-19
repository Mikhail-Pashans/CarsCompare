using CarsCompare.Database;
using CarsCompare.Database.Models.Data;
using CarsCompare.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsCompare.Domain.BusinessObjects
{
    public class ParamNameBO : BaseBO
    {
        public ParamNameBO(IUnitOfWork uow) : base(uow) { }

        public async Task<IEnumerable<ParamNameModel>> GetParamNames()
        {
            var paramNames = await UnitOfWork.ParamNameRepository.GetAllAsync();
            var paramNameModels = paramNames.Select(Map).ToList();

            return paramNameModels;
        }

        public ParamNameModel Map(ParamName paramName)
        {
            if (paramName == null)
                return null;

            return new ParamNameModel
            {
                Id = paramName.Id,
                Name = paramName.Name,
                Units = paramName.Units
            };
        }
    }
}