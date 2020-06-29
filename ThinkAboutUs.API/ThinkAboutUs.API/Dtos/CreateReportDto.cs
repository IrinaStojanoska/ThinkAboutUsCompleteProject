using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkAboutUs.API.Dtos
{
    public class CreateReportDto
    {
        public string ContactNumber { get; set; }

        public string ContactEmail { get; set; }

        public CreateDogDto Dog { get; set; }
    }
}
