using Dapper;
using MCB.MasterPiece.Data.CollectionClasses;
using MCB.MasterPiece.Data.EntityClasses;
using MCB.MasterPiece.Data.HelperClasses;
using MCB.Memphis.Core.Model;
using MCB.Memphis.Core.Services;
using Microsoft.Extensions.Configuration;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Memphis.Services.News
{
    public class NewsService : INewsService
    {
        public NewsService()
        {
        }        
        public NewsModel GetNews(int newsGuid)
        {            
            var siteNewsEntity = GetSiteNewsEntity(newsGuid);
            return siteNewsEntity != null ? ToNewsModel(siteNewsEntity) : null;
        }
        private SiteNewsEntity GetSiteNewsEntity(int newsGuid)
        {
            SiteNewsCollection siteNewsCollection = new SiteNewsCollection();
            IPredicateExpression filter = new PredicateExpression();
            filter.Add(SiteNewsFields.NewsGuid == newsGuid);
            siteNewsCollection.GetMulti(filter);

            if (siteNewsCollection.Count == 0)
                return null;
            else
                return siteNewsCollection[0];
        }

        public List<NewsModel> GetAllNews(int siteGuid)
        {
            SiteNewsCollection siteNewsCollection = new SiteNewsCollection();
            IPredicateExpression filter = new PredicateExpression();
            filter.Add(SiteNewsFields.SiteGuid == siteGuid);

            if (siteNewsCollection.GetMulti(filter))
            {
                return siteNewsCollection.Select(m => ToNewsModel(m)).ToList();
            }
            return null;
           
        }

        public bool Update(NewsModel newsModel)
        {
            var siteNewsEntity = FromNewsModel(newsModel);
            siteNewsEntity.Save();
            return true;
        }

        

        public bool Delete(int newsGuid)
        {
            var siteNewsEntity = GetSiteNewsEntity(newsGuid);
            return siteNewsEntity.Delete();
        }

        public Task<NewsModel> GetNewsAsync(int newsGuid)
        {
            return Task.Run(() => {
                return GetNews(newsGuid);
            });
        }

        public Task<List<NewsModel>> GetAllNewsAsync(int siteGuid)
        {
            return Task.Run(() =>
            {
                return GetAllNews(siteGuid);
            });
        }

        public Task<bool> UpdateAsync(NewsModel newsModel)
        {
            return Task.Run(() =>
            {
                return Update(newsModel);
            });
        }

        public Task<bool> DeleteAsync(int newsGuid)
        {
            return Task.Run(() =>
            {
                return Delete(newsGuid);
            });
        }
        private NewsModel ToNewsModel(SiteNewsEntity siteNewsEntity)
        {
            if (siteNewsEntity == null) return null;
            return new NewsModel
            {
                NewsGuid = siteNewsEntity.NewsGuid,
                SiteGuid = siteNewsEntity.SiteGuid.GetValueOrDefault(),
                MetaDescription = siteNewsEntity.MetaDescription,
                LogicalName = siteNewsEntity.LogicalName,
                NewsEndDate = siteNewsEntity.NewsEndDate.GetValueOrDefault(),
                NewsFreeTxt = siteNewsEntity.NewsFreeTxt,
                NewsHead = siteNewsEntity.NewsHead.GetValueOrDefault() == 1,
                NewsHeadline = siteNewsEntity.NewsHeadline,
                NewsKeywords = siteNewsEntity.NewsKeywords,
                NewsManchet = siteNewsEntity.NewsManchet,
                NewsStartDate = siteNewsEntity.NewsStartDate.GetValueOrDefault(),
                NewsText = siteNewsEntity.NewsText,
                PageTitle = siteNewsEntity.PageTitle,
                SubGroupGuid = siteNewsEntity.SubGroupGuid.GetValueOrDefault()
            };
        }
        private SiteNewsEntity FromNewsModel(NewsModel newsModel)
        {
            return new SiteNewsEntity
            {
                NewsGuid = newsModel.NewsGuid,
                SiteGuid = newsModel.SiteGuid,
                MetaDescription = newsModel.MetaDescription,
                LogicalName = newsModel.LogicalName,
                NewsEndDate = newsModel.NewsEndDate,
                NewsFreeTxt = newsModel.NewsFreeTxt,
                NewsHead = newsModel.NewsHead ? 1 : 0,
                NewsHeadline = newsModel.NewsHeadline,
                NewsKeywords = newsModel.NewsKeywords,
                NewsManchet = newsModel.NewsManchet,
                NewsStartDate = newsModel.NewsStartDate,
                NewsText = newsModel.NewsText,
                PageTitle = newsModel.PageTitle,
                SubGroupGuid = newsModel.SubGroupGuid
            };
        }

    }
}
