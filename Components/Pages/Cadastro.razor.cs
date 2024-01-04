using Microsoft.AspNetCore.Components;
using StockMasterFy.Components.Layout;
using StockMasterFy.Model;
using StockMasterFy.Services;

namespace StockMasterFy.Components.Pages
{
    public class CadastroBase : SmComponentBase
    {
        [Inject]
        public IUsuarioService UsuarioService { get; set; }

        protected string loginUser = null;
        protected string senhaUser = null;
        protected string confirmeSenhaUser = null;
        protected string nomeUser = null;

        protected async Task OnClickLogin()
        {
            Usuario usuarioAux = null;

            try
            {
                if (!await ValidaDados())
                {
                    return;
                }

                usuarioAux = new Usuario { DsLogin = loginUser, DsNome = nomeUser, DsSenha = senhaUser };

                if (!await UsuarioService.InsereNovoUsuario(usuarioAux))
                {
                    await Util.MostraMensagem(DialogServiceAux, "login já cadastrado no servidor!");
                    return;
                }

                await Util.MostraMensagem(DialogServiceAux, "cadastro realizado com sucesso!");
            }
            catch (Exception err)
            {
                await Util.TrataErro(DialogServiceAux, err);
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

            if (senhaUser.Length < 8)
            {
                await Util.MostraMensagem(DialogServiceAux, "O campo senha deve ter pelo menos 8 caracteres!");
                return false;
            }

            if (String.IsNullOrWhiteSpace(confirmeSenhaUser))
            {
                await Util.MostraMensagem(DialogServiceAux, "O campo de confirme senha não pode ficar em branco!");
                return false;
            }

            if (String.IsNullOrWhiteSpace(nomeUser))
            {
                await Util.MostraMensagem(DialogServiceAux, "O campo nome não pode ficar em branco!");
                return false;
            }

            if (!senhaUser.Equals(confirmeSenhaUser))
            {
                await Util.MostraMensagem(DialogServiceAux, "O campo confirme senha está inválido!");
                return false;
            }

            return true;
        }
    }
}
