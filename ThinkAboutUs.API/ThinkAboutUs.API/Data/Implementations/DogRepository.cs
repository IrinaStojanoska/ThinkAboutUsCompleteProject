using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkAboutUs.API.Data.Context;
using ThinkAboutUs.API.Data.Entities;
using ThinkAboutUs.API.Helpers;

namespace ThinkAboutUs.API.Data.Implementations
{
    public class DogRepository : IDogRepository
    {
        private readonly ThinkAboutUsContext _db;

        public DogRepository(ThinkAboutUsContext db)
        {
            _db = db;
        }

        public DogEntity Add(DogEntity dog)
        {
            _db.Dogs.Add(dog);
            _db.SaveChanges();

            return dog;
        }

        public bool Delete(int id)
        {
            var dog = Get(id);
            if(dog is null)
            {
                return false;
            }

            _db.Dogs.Remove(dog);
            _db.SaveChanges();

            return true;
        }

        public IEnumerable<DogEntity> GetLost()
        {
            return _db.Dogs
                .Where(x => x.Status == Status.Lost || x.Status == Status.PendingFound)
                .Include(x => x.Size);
        }

        public IEnumerable<DogEntity> GetAdoptedDogs()
        {
            return _db.Dogs
                .Where(x => x.Status == Status.Adopted)
                .Include(x => x.Size);
        }

        public IEnumerable<DogEntity> GetFoundDogs()
        {
            return _db.Dogs
                .Where(x => x.Status == Status.Found)
                .Include(x => x.Size);
        }

        public IEnumerable<SizeEntity> GetDogSizes()
        {
            return _db.Sizes;
        }

        public SizeEntity GetSize(int sizeId)
        {
            return _db.Find<SizeEntity>(sizeId);
        }

        public DogEntity Get(int id)
        {
            var dog = _db.Dogs.Include(x => x.Size).SingleOrDefault(x => x.Id == id);
            return dog;
        }

        public IEnumerable<DogEntity> GetAll()
        {
            return _db.Dogs.Include(x => x.Size);
        }

        public IEnumerable<DogEntity> GetHomeless()
        {
            return _db.Dogs
                .Where(x => x.Status == Status.Homeless || x.Status == Status.PendingAdoption)
                .Include(x => x.Size);
        }

        public bool Update(DogEntity dog)
        {

            _db.Entry(dog).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(dog.Id))
                {
                    throw;
                }
                else
                {
                    throw;
                }
            }
            var d = Get(dog.Id);
            if(d is null)
            {
                return false;
            }

            _db.Dogs.Update(dog);
            _db.SaveChanges();

            return true;
        }

        private bool DogExists(int id)
        {
            return _db.Dogs.Any(e => e.Id == id);
        }
    }
}
