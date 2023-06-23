using WebApplicationAPI.Models;

namespace WebApplicationAPI.ViewModels
{
    public class LibroViewModel
    {
        public List<LibroModel> libros { get; set; }
        public PaginationInfo pagination { get; set; }
    }
}
