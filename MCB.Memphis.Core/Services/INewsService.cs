using MCB.Memphis.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Memphis.Core.Services
{
    public interface INewsService
    {
        Task<NewsModel> GetNews(int newsGuid);
        Task<List<NewsModel>> GetAllNews(int siteGuid);
        Task<bool> Udpate(NewsModel newsModel);
        Task<bool> Delete(int newsGuid);       
    }
}
