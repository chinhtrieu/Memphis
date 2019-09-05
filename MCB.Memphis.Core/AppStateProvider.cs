using MCB.MasterPiece.Data.EntityClasses;
using MCB.Memphis.Core.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MCB.Memphis.Core
{
    public class AppStateProvider
    {
        private AdminUserEntity _adminUserEntity;
        public AppStateProvider(IAdminUserService adminUserService, AuthenticationStateProvider authenticationStateProvider)
        {
            var user = authenticationStateProvider.GetAuthenticationStateAsync().Result.User;
            if (user.Identity.IsAuthenticated && int.TryParse(user.Claims.FirstOrDefault(m => m.Type.ToString() == "UserGuid").Value, out int userGuid))
            {
                _adminUserEntity = adminUserService.GetAdminUser(userGuid);
            }
        }
        private int _siteGuid;        
        public int SiteGuid
        {
            get
            {
                if (_siteGuid <= 0)
                {
                    if (_adminUserEntity != null)
                    {
                        _siteGuid = _adminUserEntity.MyAccumoloLastSiteGuid.GetValueOrDefault(10535);
                    }
                }
                return _siteGuid;
            }
            set
            {
                _siteGuid = value;
                _adminUserEntity.MyAccumoloLastSiteGuid = value;
                _adminUserEntity.Save();
                if (OnSiteGuidChanged != null)
                {
                    OnSiteGuidChanged.Invoke();
                }
            }

        }
        public Action OnSiteGuidChanged { get; set; }
        public int UserGuid => _adminUserEntity != null ? _adminUserEntity.UserGuid : 0;            
        
    }
}
