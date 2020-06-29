using System.Collections.Generic;
using ThinkAboutUs.API.Data.Entities;

namespace ThinkAboutUs.API.Data
{
    public interface IReportRepository
    {
        void AddReport(ReportEntity report);

        IEnumerable<ReportEntity> GetAll();

        ReportEntity Get(int id);

        bool Delete(int id);

        bool SaveAll();
    }
}
