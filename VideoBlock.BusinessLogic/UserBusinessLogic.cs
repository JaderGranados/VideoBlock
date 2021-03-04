using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoBlock.Common.Enums;
using VideoBlock.Common.Interfaces;
using VideoBlock.Common.ViewModels;
using VideoBlock.Persistence.DbContext;
using VideoBlock.Persistence.Models;
using VideoBlock.Security;

namespace VideoBlock.BusinessLogic
{
    public class UserBusinessLogic : IUserManager
    {
        public async Task Booking(int id, IList<int> bookings)
        {
            try
            {
                using (VideoBlockDbContext _context = new VideoBlockDbContext())
                {
                    var user = await _context.User.FindAsync(id);
                    if (user == null)
                    {
                        throw new Exception(message: "El usuario especificado no está registrado en la base de datos");
                    }

                    foreach (int movie in bookings)
                    {
                        var pelicula = await _context.Movie.FindAsync(movie);
                        if (pelicula.Stock != 0)
                        {
                            pelicula.Stock -= 1;
                            if (!user.Bookings.Any(x => x.IdMovie == movie))
                            {
                                user.Bookings.Add(new Book
                                {
                                    IdMovie = movie
                                });
                            }
                        }
                        else
                        {
                            throw new Exception(message: "La película no tiene reservas disponibles");
                        }
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<UserViewModel>> GetAll()
        {
            try
            {
                using (VideoBlockDbContext _context = new VideoBlockDbContext())
                {
                    return await _context.User.Select(e => new UserViewModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        LastName = e.LastName,
                        UserName = e.Password,
                        Bookings = string.Join(", ", e.Bookings.Select(x => x.Movie.Title).ToArray())
                    }).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UserViewModel> GetUserByUserName(string username)
        {
            try
            {
                using (VideoBlockDbContext _context = new VideoBlockDbContext())
                {
                    return await _context.User.Select(x => new UserViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        LastName = x.LastName,
                        UserName = x.UserName,
                        Bookings = string.Join(", ", x.Bookings.Select(e => e.Movie.Title).ToArray()),
                        IdRol = x.IdRole
                    }).FirstOrDefaultAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> Login(LoginViewModel model)
        {
            try
            {
                using (VideoBlockDbContext _context = new VideoBlockDbContext())
                {
                    string password = PasswordEncryptHelper.Encrypt(model.Password);

                    var user = await _context.User.Where(x => x.UserName == model.UserName && x.Password == password).FirstOrDefaultAsync();
                    if (user == null)
                    {
                        throw new Exception(message: "Datos incorrectos");
                    }
                    user.Token = Guid.NewGuid().ToString();

                    await _context.SaveChangesAsync();

                    return await Task.FromResult(user.Token);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Save(UserViewModel entity)
        {
            try
            {
                using VideoBlockDbContext _context = new VideoBlockDbContext();
                if (_context.User.Any(x => x.UserName == entity.UserName.Trim()))
                {
                    throw new Exception(message: "Existe un elemento con este usuario en la base de datos");
                }
                var user = new User
                {
                    Name = entity.Name.Trim(),
                    LastName = entity.LastName.Trim(),
                    Password = PasswordEncryptHelper.Encrypt(entity.Password.Trim()),
                    UserName = entity.UserName.Trim(),
                    IdRole = (int)RolesEnum.Cliente
                };

                _context.User.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, UserViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
