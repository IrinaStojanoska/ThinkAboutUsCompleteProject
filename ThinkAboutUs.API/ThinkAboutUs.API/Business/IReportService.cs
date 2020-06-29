using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkAboutUs.API.Dtos;

namespace ThinkAboutUs.API.Business
{
    public interface IReportService
    {
        void AddReport(CreateReportDto report);

        IEnumerable<ReportDto> GetAll();

        ReportDto Get(int id);

        bool Delete(int id);

        void NotifySubmitter(ReportDto report);

        IEnumerable<ReportDto> GetPending();
    }
}
