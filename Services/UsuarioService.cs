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
            usuario.DsNome = "";

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync<Usuario>("api/usuario", usuario);

            string jsonString = await httpResponseMessage.Content.ReadAsStringAsync();

            Usuario usuarioAux = JsonConvert.DeserializeObject<Usuario>(jsonString);

            return usuarioAux;
        }

        public async Task<bool> InsereNovoUsuario(Usuario usuario)
        {
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsJsonAsync<Usuario>("api/usuario/insere", usuario);

            string jsonString = await httpResponseMessage.Content.ReadAsStringAsync();

            bool usuarioInserido = JsonConvert.DeserializeObject<bool>(jsonString);

            return usuarioInserido;
        }
    }
}
