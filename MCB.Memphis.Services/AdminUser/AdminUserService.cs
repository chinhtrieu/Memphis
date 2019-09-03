using MCB.MasterPiece.Data.CollectionClasses;
using MCB.MasterPiece.Data.EntityClasses;
using MCB.MasterPiece.Data.HelperClasses;
using MCB.MasterPiece.Hashing.Services.Interfaces;
using MCB.MasterPiece.Site.AdminSite;
using MCB.Memphis.Core.Services;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCB.Memphis.Services.AdminUser
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IHashingService _hashingService;
        public AdminUserService(IHashingService hashingService)
        {
            _hashingService = hashingService;
        }

        public AdminUserEntity CheckUserLogin(SiteAdminTypeEnum adminSiteType, string userName, string password)
        {
            var adminUserCollection = GetAdminUserCollection(adminSiteType, userName, null, null);
            var adminUser = adminUserCollection.FirstOrDefault(x => x.UserPassword == password & !x.IsDeactivated);
            return adminUser;
        }
        public AdminUserEntity CheckUserLoginWithHash(SiteAdminTypeEnum adminSiteType, string userName, string password)
        {
            AdminUserEntity adminUserEntity;
            try
            {
                var adminUserCollection = GetAdminUserCollection(adminSiteType, userName, null, null);
                adminUserEntity = adminUserCollection.FirstOrDefault(x => _hashingService.VerifyHash(password, x.UserPasswordHash) && !x.IsDeactivated);
            }
            catch (Exception ex)
            {
                // todo
                return null;
            }

            return adminUserEntity;
        }
        public AdminUserCollection GetAdminUserCollection(SiteAdminTypeEnum adminSiteType, string userName, string email, string token)
        {
            var userCollection = new AdminUserCollection();
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(token)) return userCollection;

            var filter = new PredicateExpression();
            var relations = new RelationCollection();

            if (adminSiteType == SiteAdminTypeEnum.Accumolo)
            {
                relations.Add(AdminUserEntityBase.Relations.AdminUserAccessEntityUsingUserGuid);
                relations.Add(AdminUserAccessEntityBase.Relations.AdminSiteModuleEntityUsingSiteModuleGuid);
                relations.Add(AdminSiteModuleEntityBase.Relations.AdminSitesEntityUsingSiteGuid);
                filter.AddWithAnd(AdminSitesFields.AccountingMarkAsInactive != 1);
            }
            else if (adminSiteType == SiteAdminTypeEnum.Management)
            {
                filter.Add(AdminUserFields.UserManagementAccess == true);
            }

            if (!string.IsNullOrEmpty(userName))
            {
                filter.AddWithAnd(AdminUserFields.UserName == userName);
            }
            if (!string.IsNullOrEmpty(email))
            {
                filter.AddWithAnd(AdminUserFields.UserEmail == email);
            }
            if (!string.IsNullOrEmpty(token))
            {
                filter.AddWithAnd(AdminUserFields.UserPasswordResetToken == token);
                filter.AddWithAnd(AdminUserFields.TokenExpiration >= DateTime.Now);
            }

            userCollection.GetMulti(filter, relations);
            return userCollection;
        }
    }
}
