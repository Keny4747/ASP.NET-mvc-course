using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;
using WebApplicationAPI.ViewModels;

namespace WebApplicationAPI.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly ApplicationDBContext applicationDBContext;
        public LibroRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public void Actualizar(LibroModel model)
        {
            applicationDBContext.Entry(model).State = EntityState.Modified;
            applicationDBContext.SaveChanges();
        }

        public void Crear(LibroModel model)
        {
            applicationDBContext.libroCollection.Add(model);
            applicationDBContext.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var model = applicationDBContext.libroCollection.Find(id);
            if (model != null)
            {
                applicationDBContext.libroCollection.Remove(model);
            }
            applicationDBContext.SaveChangesAsync();
        }

        public LibroModel ObtenerPorID(int id)
        {
            return applicationDBContext.libroCollection.Find(id);
        }

        public LibroModel ObtenerPorNombre(string nombre_usuario)
        {
            var user = applicationDBContext.libroCollection.FirstOrDefault(u => u.titulo == nombre_usuario);
            return user;
        }

        public List<LibroModel> ObtenerTodos()
        {
            return applicationDBContext.libroCollection.ToList();
        }

        public LibroViewModel ObtenerTodosPagination(int pageNumber, int pageSize)
        {
            var totalItems = applicationDBContext.libroCollection.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var currentPageList = applicationDBContext.libroCollection.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var viewModel = new LibroViewModel
            {
                libros = currentPageList,
                pagination = new PaginationInfo
                {
                    currentPage = pageNumber,
                    totalItems = totalItems,
                    totalPages = totalPages,
                    pageSize = pageSize
                }
            };
            return viewModel;
        }
    }
}
