using Common.Interfaces;
using Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoBlock.Persistence.DbContext;
using VideoBlock.Persistence.Models;

namespace VideoBlock.BusinessLogic
{
    public class MovieBusinessLogic : IEntityManager<MovieViewModel, int>
    {
        public async Task<IList<MovieViewModel>> GetAll()
        {
            try
            {
                using (VideoBlockDbContext _context = new VideoBlockDbContext())
                {
                    return await _context.Movie.Select(e => new MovieViewModel
                    {
                        Id = e.Id,
                        CantidadInventario = e.Stock,
                        CostoAlquiler = e.Price,
                        Descripcion = e.Description,
                        Director = $"{e.Director.Name} {e.Director.LastName}",
                        Actores = string.Join(", ", e.Actors.Select(x => $"{x.Person.Name} {x.Person.LastName}").ToArray()),
                        Titulo = e.Title
                    }).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Save(MovieViewModel entity)
        {
            try
            {
                using (VideoBlockDbContext _context = new VideoBlockDbContext())
                {
                    var movie = new Movie
                    {
                        Description = entity.Descripcion,
                        IdDirector = entity.IdDirector,
                        Price = entity.CostoAlquiler,
                        Stock = entity.CantidadInventario,
                        Title = entity.Titulo
                    };

                    foreach(int idActor in entity.ActoresId)
                    {
                        movie.Actors.Add(new PersonMovie
                        {
                            IdPerson = idActor
                        });
                    }
                    _context.Movie.Add(movie);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task SoftDelete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(int id, MovieViewModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
