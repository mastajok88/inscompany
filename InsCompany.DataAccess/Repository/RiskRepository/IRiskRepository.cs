using System.Collections.Generic;
using InsCompany.DataAccess.Models;

namespace InsCompany.DataAccess.Repository.RiskRepository
{
    public interface IRiskRepository
    {
        List<Risk> GetList();

        Risk Get(int entityId);

        void Update(Risk[] entities);

        Risk Delete(int entityId);
    }
}