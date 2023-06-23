using System.Data;
using WebApplicationAPI.Models;
using WebApplicationAPI.Repository;

namespace WebApplicationAPI.Service
{
    public class LibroService :ILibroService
    {
        private readonly ILibroRepository libroRepository;
        private readonly ApplicationDBContext applicationDBContext;

        public LibroService(ILibroRepository libroRepository)
        {
            this.libroRepository = libroRepository;
            this.applicationDBContext = applicationDBContext;
        }

        public bool RegistrarLibro(LibroModel libro)
        {
            using (var transaction = applicationDBContext.Database.BeginTransaction())
            {
                try
                {
                    libroRepository.Crear(libro);
            
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
