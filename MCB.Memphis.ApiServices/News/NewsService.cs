using MCB.Memphis.Core.Model;
using MCB.Memphis.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Memphis.ApiServices.News
{
    public class NewsService : INewsService
    {
        public Task<bool> Delete(int newsGuid)
        {
            throw new NotImplementedException();
        }

        public Task<List<NewsModel>> GetAllNews(int siteGuid)
        {
            throw new NotImplementedException();
        }

        public Task<NewsModel> GetNews(int newsGuid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Udpate(NewsModel newsModel)
        {
            throw new NotImplementedException();
        }
    }
}
