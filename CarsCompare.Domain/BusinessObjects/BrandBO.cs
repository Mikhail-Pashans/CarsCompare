using CarsCompare.Database;
using CarsCompare.Database.Models.Data;
using CarsCompare.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsCompare.Domain.BusinessObjects
{
    public class BrandBO : BaseBO
    {
        public BrandBO(IUnitOfWork uow) : base(uow) { }

        public async Task<IEnumerable<BrandModel>> GetBrands()
        {
            var brands = await UnitOfWork.BrandRepository.GetAllAsync();
            var brandModels = brands.ToList().Select(Map).OrderBy(b => b.Name);

            return brandModels;
        }

        public static BrandModel Map(Brand brand)
        {
            if (brand == null)
                return null;

            return new BrandModel
            {
                Id = brand.Id,
                Name = brand.Name
            };
        }
    }
}