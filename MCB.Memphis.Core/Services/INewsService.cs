using MCB.Memphis.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Memphis.Core.Services
{
    public interface INewsService
    {
        NewsModel GetNews(int newsGuid);
        List<NewsModel> GetAllNews(int siteGuid);
        bool Udpate(NewsModel newsModel);
        bool Delete(int newsGuid);       
    }
}
