using Microsoft.AspNetCore.Components;
using MudBlazor;
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

        protected bool mostrarSenha;
        protected InputType senhaInput = InputType.Password;
        protected string senhaInputIcon = Icons.Material.Filled.VisibilityOff;

        protected bool mostrarConfirmarSenha;
        protected InputType confirmarSenhaInput = InputType.Password;
        protected string confirmarSenhaInputIcon = Icons.Material.Filled.VisibilityOff;

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
                    await Util.MostraMensagem(DialogServiceAux, "email já cadastrado no servidor!");
                    return;
                }

                await Util.MostraMensagem(DialogServiceAux, "cadastro realizado com sucesso!");

                NavigationManagerAux.NavigateTo("home");
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

        protected async Task OnClickIconSenha()
        {
            try
            {
                if (mostrarSenha)
                {
                    mostrarSenha = false;
                    senhaInputIcon = Icons.Material.Filled.VisibilityOff;
                    senhaInput = InputType.Password;
                }
                else
                {
                    mostrarSenha = true;
                    senhaInputIcon = Icons.Material.Filled.Visibility;
                    senhaInput = InputType.Text;
                }

                StateHasChanged();
            }
            catch (Exception err)
            {
                await Util.TrataErro(DialogServiceAux, err);
            }
        }

        protected async Task OnClickIconConfirmarSenha()
        {
            try
            {
                if (mostrarConfirmarSenha)
                {
                    mostrarSenha = false;
                    confirmarSenhaInputIcon = Icons.Material.Filled.VisibilityOff;
                    confirmarSenhaInput = InputType.Password;
                }
                else
                {
                    mostrarConfirmarSenha = true;
                    confirmarSenhaInputIcon = Icons.Material.Filled.Visibility;
                    confirmarSenhaInput = InputType.Text;
                }

                StateHasChanged();
            }
            catch (Exception err)
            {
                await Util.TrataErro(DialogServiceAux, err);
            }
        }

    }
}
