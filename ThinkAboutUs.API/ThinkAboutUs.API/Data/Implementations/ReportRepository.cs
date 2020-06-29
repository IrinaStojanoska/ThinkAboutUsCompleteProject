using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ThinkAboutUs.API.Data.Context;
using ThinkAboutUs.API.Data.Entities;

namespace ThinkAboutUs.API.Data.Implementations
{
    public class ReportRepository : IReportRepository
    {
        private readonly ThinkAboutUsContext _db;

        public ReportRepository(ThinkAboutUsContext db)
        {
            _db = db;
        }

        public void AddReport(ReportEntity report)
        {
            _db.Reports.Add(report);
            _db.SaveChanges();
        }

        public IEnumerable<ReportEntity> GetAll()
        {
            var reports = _db.Reports;
            return reports;
        }

        public ReportEntity Get(int id)
        {
            var report = _db.Reports.Find(id);
            return report;
        }

        public bool Delete(int id)
        {
            var report = Get(id);
            if (report is null)
                return false;

            _db.Reports.Remove(report);
            _db.SaveChanges();

            return true;
        }

        public bool SaveAll()
        {
            return _db.SaveChanges() > 0;
        }
    }
}
