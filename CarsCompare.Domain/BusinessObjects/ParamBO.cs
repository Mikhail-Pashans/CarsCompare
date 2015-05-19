﻿using CarsCompare.Database;
using CarsCompare.Database.Models.Data;
using CarsCompare.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsCompare.Domain.BusinessObjects
{
    public class ParamBO : BaseBO
    {
        public ParamBO(IUnitOfWork uow) : base(uow) { }

        public async Task<IEnumerable<ParamModel>> GetParams()
        {
            var parameters = await UnitOfWork.ParamRepository.GetAllAsync();
            var paramModels = parameters.Take(1000).Select(Map).ToList();

            return paramModels;
        }

        public async Task<IEnumerable<ParamModel>> GetParamsByModifyIdAndParamNameId(int modifyId, int paramNameId)
        {
            var parameters = await UnitOfWork.ParamRepository.FindAsync(p => p.Modify.Id == modifyId && p.ParamName.Id == paramNameId);
            var paramModels = parameters.Take(1000).Select(Map).ToList();

            return paramModels;
        }

        public ParamModel Map(Param param)
        {
            if (param == null)
                return null;

            return new ParamModel
            {
                Id = param.Id,
                Value = param.Value
            };
        }
    }
}