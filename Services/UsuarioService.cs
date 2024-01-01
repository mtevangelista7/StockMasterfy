using StockMasterFy.Model;

namespace StockMasterFy.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await httpClient.GetFromJsonAsync<Usuario[]>("api/usuarios");
        }
    }
}
