using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IEntityManager<T, S> 
        where T: class
        where S: struct
    {
        /// <summary>
        /// Retorna un listado de la entidad referenciada
        /// </summary>
        /// <returns>Listado de <typeparamref name="T"/></returns>
        Task<IList<T>> GetAll();
        /// <summary>
        /// Guarda un valor de <typeparamref name="T"/> en la base de datos
        /// </summary>
        /// <param name="entity">Entidad a guardar</param>
        Task Save(T entity);
        /// <summary>
        /// Actualiza la entidad de tipo <typeparamref name="T"/> idenfiticada con el identificador <paramref name="id"/>
        /// </summary>
        /// <param name="id">Identificador de la entidad</param>
        /// <param name="entity">Entidad a actualizar</param>
        Task Update(S id, T entity);
        /// <summary>
        /// Cambia el campo activo de la entidad en la base de datos
        /// </summary>
        /// <param name="id">Identificador de la entidad</param>
        Task SoftDelete(S id);

    }
}
