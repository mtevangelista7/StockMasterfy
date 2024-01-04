using Microsoft.AspNetCore.Components;
using MudBlazor;
using StockMasterFy.Components.Layout;
using StockMasterFy.Model;
using StockMasterFy.Services;

namespace StockMasterFy.Components.Pages
{
    public class LoginBase : SmComponentBase
    {
        [Inject]
        public IUsuarioService UsuarioService { get; set; }

        protected string loginUser = null;
        protected string senhaUser = null;

        protected async Task OnClickLogin()
        {
            Usuario usuarioAux = null;

            try
            {
                if (!await ValidaDados())
                {
                    return;
                }

                // Cria um objeto com as informações digitadas
                usuarioAux = new Usuario { DsLogin = loginUser.Trim(), DsSenha = senhaUser.Trim() };

                // Chama o serviço para validar o usuario
                usuarioAux = await UsuarioService.RetornaUsuarioLoginSenha(usuarioAux);

                // Caso não tenha localizado o usuario
                if (usuarioAux == null || usuarioAux.DsLogin == null)
                {
                    await Util.MostraMensagem(DialogServiceAux, "O login é inválido!");
                    return;
                }

                usuarioAux.DsSenha = null;

                // Armazena o usuario nos cookies
                await Util.ArmazenaUsuarioCookie(JSRuntimeAux, CryptoServiceAux, usuarioAux);
            }
            catch (Exception err)
            {
                await Util.TrataErro(DialogServiceAux, err);
            }
            finally
            {

            }
        }

        private async Task<bool> ValidaDados()
        {
            if (String.IsNullOrWhiteSpace(loginUser))
            {
                await Util.MostraMensagem(DialogServiceAux, "O campo login não pode ficar em branco!");
                return false;
            }

            if (String.IsNullOrWhiteSpace(senhaUser))
            {
                await Util.MostraMensagem(DialogServiceAux, "O campo senha não pode ficar em branco!");
                return false;
            }

            return true;
        }
    }
}
