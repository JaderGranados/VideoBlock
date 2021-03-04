using Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBlock.Common.ViewModels;
using VideoBlock.Persistence.DbContext;

namespace VideoBlock.BusinessLogic
{
    public class PersonaBusinessLogic : IEntityManager<PersonaViewModel, int>
    {
        public async Task<IList<PersonaViewModel>> GetAll()
        {
            try
            {
                using(VideoBlockDbContext _context = new VideoBlockDbContext())
                {
                    return await _context.Person.Select(x => new PersonaViewModel
                    {
                        Id = x.Id,
                        Nombre = $"{x.Name} {x.LastName}"
                    }).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task Save(PersonaViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, PersonaViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
