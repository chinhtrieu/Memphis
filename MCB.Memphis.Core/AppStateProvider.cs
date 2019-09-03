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
        private int _siteGuid;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public Action OnSiteGuidChanged { get; set; }

        private ClaimsPrincipal _user;
        public ClaimsPrincipal User {
            get { 
                if(_user == null)
                {
                    _user = _authenticationStateProvider.GetAuthenticationStateAsync().Result.User;
                }
                return _user;
            }
        }
        public AppStateProvider(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }
        public int SiteGuid
        {
            get {
                if (_siteGuid <= 0)
                {
                    if(User != null)
                    {
                        int.TryParse(User.Claims.FirstOrDefault(m => m.Type.ToString() == "MyAccumoloLastSiteGuid")?.Value, out _siteGuid);
                    }
                }
                return _siteGuid > 0 ? _siteGuid : 10535;
            }
            set {
                _siteGuid = value;
                if (OnSiteGuidChanged != null)
                {
                    OnSiteGuidChanged.Invoke();
                }
            }

        }

        public int UserGuid
        {
            get
            {
                int.TryParse(User.Claims.FirstOrDefault(m => m.Type.ToString() == "UserGuid")?.Value, out int userGuid);
                return userGuid;
            }
        }
    }
}
