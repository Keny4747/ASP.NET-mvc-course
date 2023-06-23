using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class VentaViewModel
    {
        public List<VentaModel> ventas { get; set; }
        public PaginationInfo paginationInfo { get; set; }
    }
}
