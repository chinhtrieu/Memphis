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

        public Task<bool> DeleteAsync(int newsGuid)
        {
            throw new NotImplementedException();
        }

        public Task<List<NewsModel>> GetAllNews(int siteGuid)
        {
            throw new NotImplementedException();
        }

        public Task<List<NewsModel>> GetAllNewsAsync(int siteGuid)
        {
            throw new NotImplementedException();
        }

        public Task<NewsModel> GetNews(int newsGuid)
        {
            throw new NotImplementedException();
        }

        public Task<NewsModel> GetNewsAsync(int newsGuid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Udpate(NewsModel newsModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(NewsModel newsModel)
        {
            throw new NotImplementedException();
        }

        public bool Update(NewsModel newsModel)
        {
            throw new NotImplementedException();
        }

        bool INewsService.Delete(int newsGuid)
        {
            throw new NotImplementedException();
        }

        List<NewsModel> INewsService.GetAllNews(int siteGuid)
        {
            throw new NotImplementedException();
        }

        NewsModel INewsService.GetNews(int newsGuid)
        {
            throw new NotImplementedException();
        }

        public bool SaveNews(NewsModel newsModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveNewsAsync(NewsModel newsModel)
        {
            throw new NotImplementedException();
        }

        public bool Insert(NewsModel newsModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(NewsModel newsModel)
        {
            throw new NotImplementedException();
        }
    }
}
