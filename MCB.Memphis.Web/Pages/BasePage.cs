using MCB.Memphis.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Memphis.Web.Pages
{
    public class BasePage : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        IComponentContext ComponentContext { get; set; }

        [Inject]
        public AppStateProvider AppState { get; set; }

        protected override async Task OnAfterRenderAsync()
        {            
            if (!ComponentContext.IsConnected)
            {
                return;
            }

            await JSRuntime.InvokeAsync<string>("InitApp");
        }
    }
}
