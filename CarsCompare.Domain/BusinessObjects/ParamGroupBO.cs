using CarsCompare.Database;
using CarsCompare.Database.Models.Data;
using CarsCompare.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsCompare.Domain.BusinessObjects
{
    public class ParamGroupBO : BaseBO
    {
        public ParamGroupBO(IUnitOfWork uow) : base(uow) { }

        public async Task<IEnumerable<ParamGroupModel>> GetParamGroups()
        {
            var paramGroups = await UnitOfWork.ParamGroupRepository.GetAllAsync();
            var paramGroupModels = paramGroups.ToList().Select(Map);

            return paramGroupModels;
        }

        public async Task<IEnumerable<ParamGroupModel>> GetParamGroupsWithParamNames()
        {
            var paramGroups = await UnitOfWork.ParamGroupRepository.FindAsync(pg => true, new[] { "ParamNames" });

            var paramGroupModels = paramGroups.ToList().Select(Map);

            return paramGroupModels;
        }

        public static ParamGroupModel Map(ParamGroup paramGroup)
        {
            if (paramGroup == null)
                return null;

            return new ParamGroupModel
            {
                Id = paramGroup.Id,
                Name = paramGroup.Name,
                ParamNames = paramGroup.ParamNames.Select(ParamNameBO.Map)
            };
        }
    }
}