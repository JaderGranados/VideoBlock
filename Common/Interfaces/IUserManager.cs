using Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoBlock.Common.ViewModels;

namespace VideoBlock.Common.Interfaces
{
    public interface IUserManager: IEntityManager<UserViewModel, int>
    {
        /// <summary>
        /// Login de usuario
        /// </summary>
        /// <param name="model">Usuario que se logueará</param>
        /// <returns>Retorna el token de logueo del usuario</returns>
        Task<string> Login(LoginViewModel model);
        /// <summary>
        /// Agrega reservas a un usuario
        /// </summary>
        /// <param name="id">Identificación del usuario en la base de datos</param>
        /// <param name="bookings">Listado de identificadores de películas registradas en la base de datos</param>
        Task Booking(int id, IList<int> bookings);
        /// <summary>
        /// Obtiene a un usuario por su nombre de usuario
        /// </summary>
        /// <param name="username">Nombre de usuario</param>
        /// <returns>Usuario buscado</returns>
        Task<UserViewModel> GetUserByUserName(string username);
    }
}
