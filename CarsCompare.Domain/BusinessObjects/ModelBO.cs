using CarsCompare.Database;
using CarsCompare.Database.Models.Data;
using CarsCompare.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsCompare.Domain.BusinessObjects
{
    public class ModelBO : BaseBO
    {
        public ModelBO(IUnitOfWork uow) : base(uow) { }

        public async Task<IEnumerable<ModelModel>> GetModels()
        {
            var models = await UnitOfWork.ModelRepository.GetAllAsync();
            var modelModels = models.Select(Map).ToList();

            return modelModels;
        }

        public ModelModel Map(Model model)
        {
            if (model == null)
                return null;

            return new ModelModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}