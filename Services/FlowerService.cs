using System;
using System.Collections.Generic;
using flowery.Models;
using flowery.Repositories;

namespace flowery.Services
{
    public class FlowerService
    {
        private readonly FlowerRepository _repo;

        public FlowerService(FlowerRepository fr)
        {
            _repo = fr;
        }

        internal IEnumerable<Flower> Get()
        {
            return _repo.Get();
        }

        internal Flower GetById(int id)
        {
            var found = _repo.GetById(id);
            if (found == null) { throw new Exception("Invalid Id"); }
            return found;
        }

        internal Flower Create(Flower newFlower)
        {
            _repo.Create(newFlower);
            return newFlower;
        }

        internal Flower Edit(Flower update)
        {
            var found = _repo.GetById(update.Id);
            if (found == null) { throw new Exception("Invalid Id"); }
            _repo.Edit(update);
            return update;
        }

        internal string Delete(int id)
        {
            var found = _repo.GetById(id);
            if (found == null) { throw new Exception("Invalid Id"); }
            _repo.Delete(id);
            return "Successfully Deleted";
        }
    }
}