using MCB.Memphis.Core.Model;
using MCB.Memphis.Core.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Memphis.Web.Pages.News
{
    public class NewsIndexComponent : ComponentBase
    {
        [Inject]
        public INewsService _newsService { get; set; }

        protected List<NewsModel> newsList;
        public NewsIndexComponent()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            newsList = _newsService.GetAllNews(10535);
        }
    }
}
