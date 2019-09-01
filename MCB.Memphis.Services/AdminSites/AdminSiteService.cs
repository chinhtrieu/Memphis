using MCB.MasterPiece.Data.CollectionClasses;
using MCB.MasterPiece.Data.EntityClasses;
using MCB.MasterPiece.Data.HelperClasses;
using MCB.Memphis.Core.Model;
using MCB.Memphis.Core.Services;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCB.Memphis.Services.AdminSites
{
    public class AdminSiteService : IAdminSiteService
    {
        public List<AdminSiteModel> GetAdminSites(int siteUserGuid)
        {
            MCB.MasterPiece.Data.CollectionClasses.AdminSitesCollection adminSites = new AdminSitesCollection();

            IRelationCollection relations = new RelationCollection();
            relations.Add(AdminSitesEntity.Relations.AdminSiteModuleEntityUsingSiteGuid);
            relations.Add(AdminSiteModuleEntity.Relations.AdminUserAccessEntityUsingSiteModuleGuid);
            relations.Add(AdminUserAccessEntity.Relations.AdminUserEntityUsingUserGuid);

            IPredicateExpression filter = new PredicateExpression();
            filter.Add(AdminUserAccessFields.UserGuid == siteUserGuid);
            filter.AddWithAnd(AdminSitesFields.AccountingMarkAsInactive != 1);

            IPredicateExpression sensitiveDataFilter = new PredicateExpression();
            sensitiveDataFilter.Add(AdminUserFields.HasAccessToSitesWithSensitiveData == 1);
            sensitiveDataFilter.AddWithOr(AdminSitesFields.SiteContainsSensitiveData == 0);
            filter.AddWithAnd(sensitiveDataFilter);

            ISortExpression sort = new SortExpression();
            sort.Add(AdminSitesFields.CostumerFullname | SortOperator.Ascending);

            adminSites.GetMulti(filter, 0, sort, relations);

            return adminSites.Select(m => ToAdminSiteModel(m)).ToList();
        }

        private AdminSiteModel ToAdminSiteModel(AdminSitesEntity adminSitesEntity)
        {
            return new AdminSiteModel
            {
                SiteGuid = adminSitesEntity.SiteGuid,
                SiteName = adminSitesEntity.CostumerFullname
            };
        }
    }
}
