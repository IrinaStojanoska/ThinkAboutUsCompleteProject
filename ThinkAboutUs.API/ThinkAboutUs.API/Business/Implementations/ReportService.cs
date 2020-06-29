using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ThinkAboutUs.API.Data;
using ThinkAboutUs.API.Data.Entities;
using ThinkAboutUs.API.Dtos;

namespace ThinkAboutUs.API.Business.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IDogService _dogService;
        private readonly IMapper _mapper;

        public ReportService(IReportRepository reportRepository,
                             IDogService dogService,
                             IMapper mapper)
        {
            _reportRepository = reportRepository;
            _dogService = dogService;
            _mapper = mapper;
        }

        public void AddReport(CreateReportDto report)
        {
           var dog = _dogService.Add(report.Dog);

           var reportEntity = new ReportEntity
           {
               ContactEmail = report.ContactEmail,
               ContactNumber = report.ContactNumber,
               DateReported = DateTime.UtcNow,
               DogId = dog.Id
           };

           _reportRepository.SaveAll();
            _reportRepository.AddReport(reportEntity);
           _reportRepository.SaveAll();
        }

        public IEnumerable<ReportDto> GetAll()
        {
            var reports = _mapper.Map<IEnumerable<ReportEntity>, IEnumerable<ReportDto>>(_reportRepository.GetAll());
            foreach (var report in reports)
            {
                report.Dog = _dogService.Get(report.DogId);
            }

            return reports;
        }

        public IEnumerable<ReportDto> GetPending()
        {
            var reports = GetAll();
            var pendingReports = new List<ReportDto>();
            foreach(var r in reports)
            {
                if(r.Dog.Status == Helpers.Status.PendingAdoption || r.Dog.Status == Helpers.Status.PendingFound)
                {
                    pendingReports.Add(r);
                }
            }
            return pendingReports;
        }


        public ReportDto Get(int id)
        {
            var report = _mapper.Map<ReportEntity, ReportDto>(_reportRepository.Get(id));
            var dog = _dogService.Get(report.DogId);
            report.Dog = dog;
            return report;
        }

        public bool Delete(int id)
        {
            return _reportRepository.Delete(id);
        }

        public void NotifySubmitter(ReportDto report)
        {
            //TODO Send e-mail that he should pick up his pet dog
        }
    }
}
