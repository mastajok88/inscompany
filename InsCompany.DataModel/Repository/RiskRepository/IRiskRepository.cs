using System.Collections.Generic;
using InsCompany.DataModel.Models;

namespace InsCompany.DataModel.Repository.RiskRepository
{
    public interface IRiskRepository
    {
        List<Risk> GetList();

        Risk Get(int riskId);

        void Add(Risk risk);

        void Edit(Risk risk);

        void Delete(int riskId);
    }
    }