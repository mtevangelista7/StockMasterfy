using Microsoft.AspNetCore.Components;
using StockMasterFy.Components.Layout;

namespace StockMasterFy.Components.Pages
{
    public class HomeBase : SmComponentBase
    {
        protected async Task OnClickProdutos()
        {
            try
            {
                NavigationManagerAux.NavigateTo("produtos");
            }
            catch (Exception err)
            {
                await Util.TrataErro(DialogServiceAux, err);
            }
        }
    }
}
