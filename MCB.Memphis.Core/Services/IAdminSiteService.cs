using MCB.MasterPiece.Data.CollectionClasses;
using MCB.Memphis.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Memphis.Core.Services
{
    public interface IAdminSiteService
    {
        AdminSitesCollection GetAdminSites(int siteUserGuid);
    }
}
