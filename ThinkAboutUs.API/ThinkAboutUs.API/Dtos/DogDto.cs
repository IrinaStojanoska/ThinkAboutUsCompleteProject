using ThinkAboutUs.API.Data.Entities;
using ThinkAboutUs.API.Helpers;

namespace ThinkAboutUs.API.Dtos
{
    public class DogDto
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        public string Code { get; set; }

        public Gender Gender { get; set; }

        public string Location { get; set; }

        public string Breed { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public SizeEntity Size { get; set; }
    }
}
