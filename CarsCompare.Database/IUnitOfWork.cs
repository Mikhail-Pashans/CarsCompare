using CarsCompare.Database.Models.Data;
using CarsCompare.Database.Models.Identity;
using CarsCompare.Database.Models.Logger;
using System;
using Version = CarsCompare.Database.Models.Data.Version;

namespace CarsCompare.Database
{
    public interface IUnitOfWork : IDisposable
    {
        System.Data.Entity.Database Database { get; }        

        #region Repository Interfaces (add one per entity)

        // Data Tables
        IGenericRepository<Brand> BrandRepository { get; }
        IGenericRepository<Model> ModelRepository { get; }
        IGenericRepository<Version> VersionRepository { get; }
        IGenericRepository<Modify> ModifyRepository { get; }
        IGenericRepository<Param> ParamRepository { get; }
        IGenericRepository<ParamName> ParamNameRepository { get; }
        IGenericRepository<ParamGroup> ParamGroupRepository { get; }

        // Logger Table
        IGenericRepository<Log> LogRepository { get; }

        // Identity tables
        IGenericRepository<AspNetUsers> AspNetUsersRepository { get; }
        IGenericRepository<AspNetRoles> AspNetRolesRepository { get; }
        IGenericRepository<AspNetUserLogins> AspNetUserLoginsRepository { get; }
        IGenericRepository<AspNetUserClaims> AspNetUserClaimsRepository { get; }

        #endregion

        void Commit();
        void EnableValidation(bool enabled);
    }
}