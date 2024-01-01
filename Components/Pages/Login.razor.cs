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
                if (usuarioAux == null)
                {
                    await Util.MostraMensagem(DialogServiceAux, "O login é inválido!");
                    return;
                }

                await Util.ArmazenaUsuarioCookie(JSRuntimeAux, CryptoServiceAux, usuarioAux);
            }
            catch (Exception err)
            {
                await Util.TrataErro(DialogServiceAux, err);
            }
        }
    }
}
