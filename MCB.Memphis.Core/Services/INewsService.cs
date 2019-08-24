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
        Task<NewsModel> GetNewsAsync(int newsGuid);
        List<NewsModel> GetAllNews(int siteGuid);
        Task<List<NewsModel>> GetAllNewsAsync(int siteGuid);
        bool Update(NewsModel newsModel);
        Task<bool> UpdateAsync(NewsModel newsModel);
        bool Delete(int newsGuid);
        Task<bool> DeleteAsync(int newsGuid);

        bool SaveNews(NewsModel newsModel);
        Task<bool> SaveNewsAsync(NewsModel newsModel);

        bool Insert(NewsModel newsModel);
        Task<bool> InsertAsync(NewsModel newsModel);
    }
}
