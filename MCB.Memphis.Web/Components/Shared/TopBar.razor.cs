using MCB.Memphis.Core;
using MCB.Memphis.Core.Model;
using MCB.Memphis.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Memphis.Web.Components.Shared
{
    public class TopBarComponent : BaseComponent
    {
        [Inject] 
        public IAdminSiteService _adminSiteService { get; set; }
        
        protected SelectList adminSiteModels { get; set; }
        protected override async Task OnInitializedAsync()
        {

            var adminSites = _adminSiteService.GetAdminSites(AppStateProvider.UserGuid);
            adminSiteModels = new SelectList(adminSites, "SiteGuid", "CostumerFullname", AppStateProvider.SiteGuid);
        }

        protected void OnSiteGuidChange(UIChangeEventArgs e)
        {
            var selectedValue = e.Value.ToString();
            if (int.TryParse(selectedValue, out int siteGuid)) 
            {
                AppStateProvider.SiteGuid = siteGuid;
            }

        }
    }
}
