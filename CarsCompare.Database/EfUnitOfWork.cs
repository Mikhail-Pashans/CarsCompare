using CarsCompare.Database.Models.Data;
using CarsCompare.Database.Models.Logger;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using Version = CarsCompare.Database.Models.Data.Version;

namespace CarsCompare.Database
{
    public class EfUnitOfWork : DbContext, IUnitOfWork
    {
        public new System.Data.Entity.Database Database { get; private set; }        

        #region Private Repos (add one per entity)

        private EfGenericRepository<Brand> _brandRepo;
        private EfGenericRepository<Model> _modelRepo;
        private EfGenericRepository<Version> _versionRepo;
        private EfGenericRepository<Modify> _modifyRepo;
        private EfGenericRepository<Param> _paramRepo;
        private EfGenericRepository<ParamName> _paramNameRepo;
        private EfGenericRepository<ParamGroup> _paramGroupRepo;

        private EfGenericRepository<Log> _logRepo;

        #endregion

        #region Public DbSets (add one per entity)

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Version> Versions { get; set; }
        public DbSet<Modify> Modifies { get; set; }
        public DbSet<Param> Params { get; set; }
        public DbSet<ParamName> ParamNames { get; set; }
        public DbSet<ParamGroup> ParamGroups { get; set; }

        public DbSet<Log> Logs { get; set; }

        #endregion

        #region Constructor

        public EfUnitOfWork() : base("BigCarBase")
        {
            Database = base.Database;
        }

        #endregion

        #region IUnitOfWork Implementation (add one per entity)

        public IGenericRepository<Brand> BrandRepository
        {
            get { return _brandRepo ?? (_brandRepo = new EfGenericRepository<Brand>(Brands)); }
        }

        public IGenericRepository<Model> ModelRepository
        {
            get { return _modelRepo ?? (_modelRepo = new EfGenericRepository<Model>(Models)); }
        }

        public IGenericRepository<Version> VersionRepository
        {
            get { return _versionRepo ?? (_versionRepo = new EfGenericRepository<Version>(Versions)); }
        }

        public IGenericRepository<Modify> ModifyRepository
        {
            get { return _modifyRepo ?? (_modifyRepo = new EfGenericRepository<Modify>(Modifies)); }
        }

        public IGenericRepository<Param> ParamRepository
        {
            get { return _paramRepo ?? (_paramRepo = new EfGenericRepository<Param>(Params)); }
        }

        public IGenericRepository<ParamName> ParamNameRepository
        {
            get { return _paramNameRepo ?? (_paramNameRepo = new EfGenericRepository<ParamName>(ParamNames)); }
        }

        public IGenericRepository<ParamGroup> ParamGroupRepository
        {
            get { return _paramGroupRepo ?? (_paramGroupRepo = new EfGenericRepository<ParamGroup>(ParamGroups)); }
        }



        public IGenericRepository<Log> LogRepository
        {
            get { return _logRepo ?? (_logRepo = new EfGenericRepository<Log>(Logs)); }
        }

        #endregion

        public void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void EnableValidation(bool enabled)
        {
            Configuration.AutoDetectChangesEnabled = enabled;
            Configuration.ValidateOnSaveEnabled = enabled;
        }

        #region Code First Overrides

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Data.Entity.Database.SetInitializer<EfUnitOfWork>(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();            
        }

        #endregion

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}