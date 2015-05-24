using CarsCompare.Database;
using CarsCompare.Database.Models.Data;
using CarsCompare.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsCompare.Domain.BusinessObjects
{
    public class VersionBO : BaseBO
    {
        public VersionBO(IUnitOfWork uow) : base(uow) { }

        public async Task<IEnumerable<VersionModel>> GetVersions()
        {
            var versions = await UnitOfWork.VersionRepository.GetAllAsync();
            var versionModels = versions.ToList().Select(Map);

            return versionModels;
        }

        public async Task<IEnumerable<VersionModel>> GetVersionsByModelId(int modelId)
        {
            var versions = await UnitOfWork.VersionRepository.FindAsync(v => v.Model.Id == modelId);
            var versionModels = versions.ToList().Select(Map);

            return versionModels;
        }

        public static VersionModel Map(Version version)
        {
            if (version == null)
                return null;

            return new VersionModel
            {
                Id = version.Id,
                Name = version.Name,
                Gen = version.Gen,
                Mod = version.Mod
            };
        }
    }
}