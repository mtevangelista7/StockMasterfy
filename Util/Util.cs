using Microsoft.JSInterop;
using MudBlazor;
using StockMasterFy.Components.Pages;
using StockMasterFy.Model;
using static MudBlazor.Colors;
using System.Text.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using StockMasterFy.Services;

namespace StockMasterFy
{
    public class Util
    {
        public static readonly string key = "YteJmOvwxs8o1dg88+gCzA==";
        public static readonly string iv = "6WDyw4W7/LWvcXuXr2GGuw==";

        public static async Task TrataErro(IDialogService dialogService, Exception err)
        {
            var options = new DialogOptions();
            var parameters = new DialogParameters
            {
                { "Mensagem", err.Message }
            };
            var dialog = await dialogService.ShowAsync<DialogMensagemConfirma>("ATENÇÃO", parameters, options);
            _ = await dialog.Result;
        }

        public static async Task MostraMensagem(IDialogService dialogService, string sMensagem)
        {
            DialogOptions options = new DialogOptions();
            DialogParameters parameters = new DialogParameters
            {
                { "Mensagem", sMensagem }
            };
            IDialogReference dialog = await dialogService.ShowAsync<DialogMensagemConfirma>("ATENÇÃO", parameters, options);
            _ = await dialog.Result;
        }

        public static async Task ArmazenaUsuarioCookie(IJSRuntime jSRuntime, ICryptoService cryptoService, Usuario usuarioAux)
        {
            string jsonString = JsonSerializer.Serialize(usuarioAux);
            string encryptedData = cryptoService.Encrypt(jsonString);

            await jSRuntime.InvokeVoidAsync("setCookie", Constantes.COOKIE_USUARIO, encryptedData);
        }

        public class Constantes
        {
            public static string COOKIE_USUARIO = "COOKIE_USUARIO";
        }
    }
}
