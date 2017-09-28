using System.Collections.Generic;
using InsCompany.DataAccess.Models;

namespace InsCompany.DataModel.Repository.RiskRepository
{
    public interface IRiskRepository
    {
        List<Risk> GetList();

        Risk Get(int entityId);

        void Update(Risk[] entities);

        Risk Delete(int entityId);
    }
}