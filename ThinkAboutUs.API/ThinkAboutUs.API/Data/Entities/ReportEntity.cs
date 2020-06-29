using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkAboutUs.API.Data.Entities
{
    public class ReportEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateReported { get; set; }

        public string ContactNumber { get; set; } // broj na onoj koj submitiral

        public string ContactEmail { get; set; }

        public int DogId { get; set; }

        public virtual DogEntity Dog { get; set; }
    }
}
