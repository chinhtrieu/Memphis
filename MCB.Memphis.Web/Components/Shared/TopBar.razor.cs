using MCB.Memphis.Core.Model;
using MCB.Memphis.Core.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Memphis.Web.Components.Shared
{
    public class TopBarComponent : ComponentBase
    {
        [Inject] public IAdminSiteService _adminSiteService { get; set; }
        protected List<AdminSiteModel> adminSiteModels { get; set; }
        protected override async Task OnInitializedAsync()
        {
            adminSiteModels = _adminSiteService.GetAdminSites(6767);
        }
    }
}
