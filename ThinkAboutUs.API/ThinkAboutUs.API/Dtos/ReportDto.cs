using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkAboutUs.API.Dtos
{
    public class ReportDto
    {
        public int Id { get; set; }

        public DateTime DateReported { get; set; }

        public string ContactNumber { get; set; } 

        public string ContactEmail { get; set; }

        public DogDto Dog { get; set; }

        public int DogId { get; set; }
    }
}
