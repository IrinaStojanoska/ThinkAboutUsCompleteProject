using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkAboutUs.API.Data.Entities;

namespace ThinkAboutUs.API.Data
{
    public interface IDogRepository
    {
        IEnumerable<DogEntity> GetAll();

        IEnumerable<DogEntity> GetHomeless();

        IEnumerable<DogEntity> GetLost();

        IEnumerable<DogEntity> GetAdoptedDogs();

        IEnumerable<DogEntity> GetFoundDogs();

        IEnumerable<SizeEntity> GetDogSizes();

        SizeEntity GetSize(int sizeId);

        DogEntity Get(int id);

        DogEntity Add(DogEntity dog);

        bool Update(DogEntity dog);

        bool Delete(int id);

    }
}
