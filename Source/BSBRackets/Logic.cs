using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repository;

namespace BSBRackets
{
    public class Logic
    {
        private readonly Repo _repo;
        private readonly Mapper _mapper;
        public Logic(Repo repo, Mapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // User controller
        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await _repo.GetUsers();
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await _repo.GetUserById(id);
        }

        public AppUser GetUserByIdNonAsync(int id)
        {
            return _repo.GetUserByIdNonAsync(id);
        }
    }
}
