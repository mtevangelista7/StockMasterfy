using Newtonsoft.Json;
using StockMasterFy.Model;
using System.Net.Http;

namespace StockMasterFy.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Usuario> RetornaUsuarioLoginSenha(Usuario usuario)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync<Usuario>("api/usuario", usuario);

            string jsonString = await httpResponseMessage.Content.ReadAsStringAsync();

            Usuario usuarioAux = JsonConvert.DeserializeObject<Usuario>(jsonString);

            return usuarioAux;
        }
    }
}
