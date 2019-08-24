using MCB.Memphis.Core.Model;
using MCB.Memphis.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCB.Memphis.MockServices.News
{
    public class NewsService : INewsService
    {
        private List<NewsModel> _newsModels;
        public NewsService()
        {
            SeedNews();
        }

        private void SeedNews()
        {
            _newsModels = new List<NewsModel>
            {
                new NewsModel { NewsGuid =1,SubGroupGuid = 1,SiteGuid = 10535,NewsStartDate = DateTime.ParseExact("7/8/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsEndDate = DateTime.ParseExact("1/17/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsHeadline = "Boudu Saved From Drowning (Boudu sauvé des eaux)",NewsManchet = "'",NewsText = "1",LogicalName= "http://dummyimage.com/136x192.bmp/ff4444/ffffff",PageTitle= "n/a",MetaDescription= "Renal anastomosis",NewsKeywords= "Unsp fx navicular bone of r wrist, subs for fx w nonunion",NewsHead= true,NewsFreeTxt= "335 Cody Circle"},
                new NewsModel { NewsGuid =2,SubGroupGuid = 2,SiteGuid = 10535,NewsStartDate = DateTime.ParseExact("10/12/2018", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsEndDate = DateTime.ParseExact("1/14/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsHeadline = "Big Tease, The",NewsManchet = "-1",NewsText = "1",LogicalName= "http://dummyimage.com/179x203.bmp/5fa2dd/ffffff",PageTitle= "n/a",MetaDescription= "Muscle reattachment",NewsKeywords= "Athscl unsp type bypass of the left leg w ulcer of unsp site",NewsHead= false,NewsFreeTxt= "1 Jenna Avenue"},
                new NewsModel { NewsGuid =3,SubGroupGuid = 3,SiteGuid = 10535,NewsStartDate = DateTime.ParseExact("5/17/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsEndDate = DateTime.ParseExact("7/8/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsHeadline = "Sonny Boy",NewsManchet = "test⁠test‫",NewsText = "1",LogicalName= "http://dummyimage.com/165x246.jpg/ff4444/ffffff",PageTitle= "Services-Misc. Amusement & Recreation",MetaDescription= "Tendon trnsfr/transplant",NewsKeywords= "Deformity of orbit",NewsHead= false,NewsFreeTxt= "51013 Rigney Way"},
                new NewsModel { NewsGuid =4,SubGroupGuid = 4,SiteGuid = 10535,NewsStartDate = DateTime.ParseExact("8/3/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsEndDate = DateTime.ParseExact("5/24/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsHeadline = "Mouse Hunt",NewsManchet = "👾 🙇 💁 🙅 🙆 🙋 🙎 🙍 ",NewsText = "0",LogicalName= "http://dummyimage.com/237x104.jpg/cc0000/ffffff",PageTitle= "Auto Parts:O.E.M.",MetaDescription= "Clubfoot release NEC",NewsKeywords= "Unspecified right bundle-branch block",NewsHead= true,NewsFreeTxt= "74323 Golden Leaf Terrace"},
                new NewsModel { NewsGuid =5,SubGroupGuid = 5,SiteGuid = 10535,NewsStartDate = DateTime.ParseExact("7/18/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsEndDate = DateTime.ParseExact("11/4/2018", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsHeadline = "Bloody Territories (Kôiki bôryoku: ryuuketsu no shima)",NewsManchet = "✋🏿 💪🏿 👐🏿 🙌🏿 👏🏿 🙏🏿",NewsText = "0",LogicalName= "http://dummyimage.com/122x160.bmp/5fa2dd/ffffff",PageTitle= "n/a",MetaDescription= "Trnsplnt islets lang NOS",NewsKeywords= "Posterior displaced fracture of sternal end of left clavicle",NewsHead= true,NewsFreeTxt= "23347 Marquette Avenue"},
                new NewsModel { NewsGuid =6,SubGroupGuid = 6,SiteGuid = 10535,NewsStartDate = DateTime.ParseExact("6/28/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsEndDate = DateTime.ParseExact("11/25/2018", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsHeadline = "Illustrated Man, The",NewsManchet = "!@#$%^&*()",NewsText = "1",LogicalName= "http://dummyimage.com/205x132.bmp/cc0000/ffffff",PageTitle= "Banks",MetaDescription= "Hypnotherapy",NewsKeywords= "Burn due to loc fire on board oth powered wtrcrft, subs",NewsHead= false,NewsFreeTxt= "06362 Manitowish Lane"},
                new NewsModel { NewsGuid =7,SubGroupGuid = 7,SiteGuid = 10535,NewsStartDate = DateTime.ParseExact("1/30/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsEndDate = DateTime.ParseExact("9/25/2018", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsHeadline = "Boy Interrupted",NewsManchet = "🚾 🆒 🆓 🆕 🆖 🆗 🆙 🏧",NewsText = "0",LogicalName= "http://dummyimage.com/134x193.png/dddddd/000000",PageTitle= "Oil & Gas Production",MetaDescription= "Close red-humerus epiphy",NewsKeywords= "Laceration of muscle, fascia and tendon of left hip, init",NewsHead= true,NewsFreeTxt= "6977 Pawling Road"},
                new NewsModel { NewsGuid =8,SubGroupGuid = 8,SiteGuid = 10535,NewsStartDate = DateTime.ParseExact("5/14/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsEndDate = DateTime.ParseExact("6/19/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsHeadline = "Dark Angel, The",NewsManchet = "사회과학원 어학연구소",NewsText = "1",LogicalName= "http://dummyimage.com/233x216.bmp/ff4444/ffffff",PageTitle= "Real Estate Investment Trusts",MetaDescription= "Eye/orbit inj repair NEC",NewsKeywords= "Inj unsp musc/tend at lower leg level, left leg, sequela",NewsHead= true,NewsFreeTxt= "46356 Parkside Center"},
                new NewsModel { NewsGuid =9,SubGroupGuid = 9,SiteGuid = 10535,NewsStartDate = DateTime.ParseExact("7/11/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsEndDate = DateTime.ParseExact("1/4/2019", "M/d/yyyy",  System.Globalization.CultureInfo.InvariantCulture), NewsHeadline = "Destroy All Monsters (Kaijû sôshingeki)",NewsManchet = "00˙Ɩ$-",NewsText = "0",LogicalName= "http://dummyimage.com/192x224.jpg/cc0000/ffffff",PageTitle= "Real Estate Investment Trusts",MetaDescription= "Bronchial ligation",NewsKeywords= "Sprain of right coracohumeral (ligament)",NewsHead= false,NewsFreeTxt= "6018 Nova Circle"},                

            };
        }

        public bool Delete(int newsGuid)
        {
            return _newsModels.RemoveAll(m => m.NewsGuid == newsGuid) > 0;
        }

        public List<NewsModel> GetAllNews(int siteGuid)
        {
            return _newsModels;
        }

        public NewsModel GetNews(int newsGuid)
        {

            return _newsModels.FirstOrDefault(m => m.NewsGuid == newsGuid);

        }

        public bool Udpate(NewsModel newsModel)
        {
            throw new NotImplementedException();
        }

        public Task<NewsModel> GetNewsAsync(int newsGuid)
        {
            return Task.Run(() =>
            {
                return GetNews(newsGuid);
            });
        }

        public Task<List<NewsModel>> GetAllNewsAsync(int siteGuid)
        {
            return Task.Run(() => { 
                return GetAllNews(siteGuid);
            });
        }

        public bool Update(NewsModel newsModel)
        {
            var index = _newsModels.FindIndex(m => m.NewsGuid == newsModel.NewsGuid);
            if(index >= 0)
            {
                _newsModels[index] = newsModel;
            }
            return index >= 0;
        }

        public Task<bool> UpdateAsync(NewsModel newsModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int newsGuid)
        {
            throw new NotImplementedException();
        }

        public bool SaveNews(NewsModel newsModel)
        {
            if(newsModel.NewsGuid > 0)
            {
                return Update(newsModel);
            }
            return Insert(newsModel);
        }

        public Task<bool> SaveNewsAsync(NewsModel newsModel)
        {
            return Task.Run(() =>
            {
                return SaveNews(newsModel);
            });
        }

        public bool Insert(NewsModel newsModel)
        {
            newsModel.NewsGuid = _newsModels.Max(m => m.NewsGuid) + 1;
            _newsModels.Add(newsModel);
            return true;
        }

        public Task<bool> InsertAsync(NewsModel newsModel)
        {
            return Task.Run(() => { 
                return Insert(newsModel);
            });
        }
    }
}
