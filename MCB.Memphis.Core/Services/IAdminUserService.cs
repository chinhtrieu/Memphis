using MCB.MasterPiece.Data.EntityClasses;
using MCB.MasterPiece.Site.AdminSite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Memphis.Core.Services
{
    public interface IAdminUserService
    {
        AdminUserEntity CheckUserLogin(SiteAdminTypeEnum adminSiteType, string userName, string password);
        AdminUserEntity CheckUserLoginWithHash(SiteAdminTypeEnum adminSiteType, string userName, string password);
        AdminUserEntity GetAdminUser(int userGuid);
    }
}
