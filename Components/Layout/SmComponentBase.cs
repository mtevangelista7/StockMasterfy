using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using StockMasterFy.Services;

namespace StockMasterFy.Components.Layout
{
    public class SmComponentBase : ComponentBase
    {
        [Inject] 
        public NavigationManager NavigationManagerAux { get; set; }
        [Inject] 
        public IJSRuntime JSRuntimeAux { get; set; }
        [Inject] 
        public IDialogService DialogServiceAux { get; set; }
        [Inject]
        public ICryptoService CryptoServiceAux{ get; set; }
    }
}
