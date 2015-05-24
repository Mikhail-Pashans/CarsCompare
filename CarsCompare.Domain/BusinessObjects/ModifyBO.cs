using CarsCompare.Database;
using CarsCompare.Database.Models.Data;
using CarsCompare.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsCompare.Domain.BusinessObjects
{
    public class ModifyBO : BaseBO
    {
        public ModifyBO(IUnitOfWork uow) : base(uow) { }

        public async Task<IEnumerable<ModifyModel>> GetModifies()
        {
            var modifies = await UnitOfWork.ModifyRepository.GetAllAsync();
            var modifyModels = modifies.ToList().Select(Map);

            return modifyModels;
        }

        public async Task<IEnumerable<ModifyModel>> GetModifiesByModelIdAndVersionId(int modelId, int versionId)
        {
            var modifies = await UnitOfWork.ModifyRepository.FindAsync(m => m.Model.Id == modelId && m.Version.Id == versionId);
            var modifyModels = modifies.ToList().Select(Map);

            return modifyModels;
        }

        public static ModifyModel Map(Modify modify)
        {
            if (modify == null)
                return null;

            return new ModifyModel
            {
                Id = modify.Id,
                Name = modify.Name,
                YearFrom = modify.YearFrom,
                YearTo = modify.YearTo
            };
        }
    }
}