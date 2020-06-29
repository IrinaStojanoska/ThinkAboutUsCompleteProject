using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThinkAboutUs.API.Business;
using ThinkAboutUs.API.Dtos;

namespace ThinkAboutUs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IDogService _dogService;

        public ReportsController(IReportService reportService,
                                 IDogService dogService)
        {
            _reportService = reportService;
            _dogService = dogService;
        }

        // GET: api/Reports
        [HttpGet]
        [Route("all")]
        [Authorize]
        public IEnumerable<ReportDto> GetReports()
        {
            var reports = _reportService.GetAll();

            return reports;
        }

        // GET: api/Reports
        [HttpGet]
        [Route("pending")]
        [Authorize]
        public IEnumerable<ReportDto> GetPending()
        {
            var reports = _reportService.GetPending();

            return reports;
        }


        // GET: api/Reports/5
        [HttpGet("{id}")]
        [Route("single/{id:int}")]
        [Authorize]
        public IActionResult GetReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var report = _reportService.Get(id);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        // POST: api/Reports
        [HttpPost]
        [Route("create")]
        public IActionResult PostReport([FromBody] CreateReportDto report)
         {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _reportService.AddReport(report);

            return Ok();
        }


        [HttpPost]
        [Route("send")]
        public IActionResult SendEmail([FromBody] ReportDto report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _reportService.NotifySubmitter(report);

            return Ok();
        }

        //DELETE REPORT !!
        // POST: api/Reports
        [HttpPost]
        [Route("deleteReportAndUpdateDog")]
        [Authorize]
        public IActionResult DeleteReportAndUpdateDog([FromBody] ReportDto report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dogService.Update(report.Dog);

            _reportService.Delete(report.Id);

            return CreatedAtAction("GetReport", new { id = report.Id }, report);
        }
    }
}