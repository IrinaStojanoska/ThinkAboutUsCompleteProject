using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkAboutUs.API.Dtos;

namespace ThinkAboutUs.API.Business
{
    public interface IDogService
    {
        IEnumerable<DogDto> GetAll();

        IEnumerable<DogDto> GetHomeless();

        IEnumerable<DogDto> GetLost();

        IEnumerable<DogDto> GetAdoptedDogs();

        IEnumerable<DogDto> GetFoundDogs();

        DogDto Get(int id);

        DogDto Add(CreateDogDto dog);

        bool Update(DogDto dog);

        bool Delete(int id);
    }
}
