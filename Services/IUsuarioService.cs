using StockMasterFy.Model;

namespace StockMasterFy.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> RetornaUsuarioLoginSenha(Usuario usuario);
        Task<bool> InsereNovoUsuario(Usuario usuario);
    }
}
