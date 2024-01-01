using StockMasterFy.Model;

namespace StockMasterFy.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
    }
}
