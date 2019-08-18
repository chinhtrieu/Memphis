using Dapper;
using MCB.Memphis.Core.Model;
using MCB.Memphis.Core.Services;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        public NewsService(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("MyConnectionString"));
            }
        }
        public NewsModel GetNews(int newsGuid)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"SELECT [NewsGuid]
                                      ,[NewsStartDate]
                                      ,[NewsEndDate]
                                      ,[NewsManchet]
                                      ,[NewsText]
                                      ,[SubGroupGuid]
                                      ,[SiteGuid]
                                      ,[NewsKeywords]
                                      ,[NewsHead]
                                      ,[NewsHeadline]
                                      ,[PageTitle]
                                      ,[MetaDescription]
                                      ,[NewsFreeTxt]
                                      ,[logicalName]
                                  FROM[dbo].[TBLsite_news] 
                                  WHERE NewsGuid = @NewsGuid";
                conn.Open();
                var result = conn.Query<NewsModel>(sQuery, new { NewsGuid = newsGuid });
                return result.FirstOrDefault();
            }
        }
        public List<NewsModel> GetAllNews(int siteGuid)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"SELECT [NewsGuid]
                                      ,[NewsStartDate]
                                      ,[NewsEndDate]
                                      ,[NewsManchet]
                                      ,[NewsText]
                                      ,[SubGroupGuid]
                                      ,[SiteGuid]
                                      ,[NewsKeywords]
                                      ,[NewsHead]
                                      ,[NewsHeadline]
                                      ,[PageTitle]
                                      ,[MetaDescription]
                                      ,[NewsFreeTxt]
                                      ,[logicalName]
                                  FROM [dbo].[TBLsite_news] 
                                  WHERE SiteGuid = @SiteGuid";
                conn.Open();
                var result = conn.Query<NewsModel>(sQuery, new { SiteGuid = siteGuid });
                return result.ToList();
            }
        }

        public bool Udpate(NewsModel newsModel)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"Update [dbo].[TBLsite_news]
                                    SET [NewsGuid] = @NewsGuid
                                      ,[NewsStartDate] = @NewsStartData
                                      ,[NewsEndDate] = @NewsEndDate
                                      ,[NewsManchet] = @NewsManchet
                                      ,[NewsText] = @NewsText
                                      ,[SubGroupGuid] = @SubGroupGuid
                                      ,[SiteGuid] = @SiteGuid
                                      ,[NewsKeywords] = @NewsKeywords
                                      ,[NewsHead] = @NewsHead
                                      ,[NewsHeadline] = @NewsHeadline
                                      ,[PageTitle] = @PageTitle
                                      ,[MetaDescription] = @MetaDescription
                                      ,[NewsFreeTxt] = @NewsFreeTxt
                                      ,[logicalName] = @LogicalName
                                    WHERE NewsGuid = @NewsGuid";
                conn.Open();
                var result = conn.Execute(sQuery, new {
                    newsModel.NewsGuid,
                    newsModel.NewsStartDate,
                    newsModel.NewsEndDate,
                    newsModel.NewsManchet,
                    newsModel.NewsText,
                    newsModel.SubGroupGuid,
                    newsModel.NewsKeywords,
                    newsModel.NewsHead,
                    newsModel.NewsHeadline,
                    newsModel.PageTitle,
                    newsModel.MetaDescription,
                    newsModel.NewsFreeTxt,
                    newsModel.LogicalName,
                });
                return result > 0;
            }
        }
        public bool Delete(int newsGuid)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"Delete FROM TBLsite_news WHERE NewsGuid = @NewsGuid";
                conn.Open();
                var result = conn.Execute(sQuery, new { NewsGuid = newsGuid });
                return result > 0;
            }
        }
    }
}
