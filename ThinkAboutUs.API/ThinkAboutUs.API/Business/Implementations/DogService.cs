 using AutoMapper;
 using System.Collections.Generic;
 using ThinkAboutUs.API.Data;
using ThinkAboutUs.API.Data.Entities;
using ThinkAboutUs.API.Dtos;

namespace ThinkAboutUs.API.Business.Implementations
{
    public class DogService : IDogService
    {
        private readonly IDogRepository _dogRepository;
        private readonly IMapper _mapper;

        public DogService(IDogRepository dogRepository,
                          IMapper mapper)
        {
            _dogRepository = dogRepository;
            _mapper = mapper;
        }

        public DogDto Add(CreateDogDto dog)
        {
            var d = _mapper.Map<CreateDogDto, DogEntity>(dog);

            var size = _dogRepository.GetSize(dog.SizeId);
            d.Size = size;

            var added = _dogRepository.Add(d);
            return _mapper.Map<DogEntity, DogDto>(added);
        }

        public bool Delete(int id)
        {   
            return _dogRepository.Delete(id);
        }

        public IEnumerable<DogDto> GetLost()
        {
            return _mapper.Map<IEnumerable<DogEntity>, IEnumerable<DogDto>>(_dogRepository.GetLost());
        }

        public IEnumerable<DogDto> GetAdoptedDogs()
        {
            return _mapper.Map<IEnumerable<DogEntity>, IEnumerable<DogDto>>(_dogRepository.GetAdoptedDogs());
        }

        public IEnumerable<DogDto> GetFoundDogs()
        {
            return _mapper.Map<IEnumerable<DogEntity>, IEnumerable<DogDto>>(_dogRepository.GetFoundDogs());
        }

        public DogDto Get(int id)
        {
            var dog = _dogRepository.Get(id);

            var dogDto = _mapper.Map<DogEntity, DogDto>(dog);

            return dogDto;
        }

        public IEnumerable<DogDto> GetAll()
        {
            var dogEntities = _dogRepository.GetAll();

            var dogs = _mapper.Map<IEnumerable<DogEntity>, IEnumerable<DogDto>>(dogEntities);

            return dogs;
        }

        public IEnumerable<DogDto> GetHomeless()
        {
            return _mapper.Map<IEnumerable<DogEntity>, IEnumerable<DogDto>>(_dogRepository.GetHomeless());
        }

        public bool Update(DogDto dog)
        {
            var dogEntity = _mapper.Map<DogDto, DogEntity>(dog);
            return _dogRepository.Update(dogEntity);
        }
    }
}
