using MCB.Memphis.Core.Model;
using MCB.Memphis.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Memphis.Web.Pages.News
{
    public class NewsEditComponent : ComponentBase
    {
        [Inject]
        public INewsService _newsService { get; set; }

        [Inject]
        public IUriHelper _uriHelper { get; set; }

        [Parameter]
        public int NewsGuid { get; set; }

        protected NewsModel newsModel;
       
        protected override async Task OnInitializedAsync()
        {
            if (NewsGuid <= 0) _uriHelper.NavigateTo("/news");
            newsModel = await _newsService.GetNews(NewsGuid);
            if(newsModel == null) _uriHelper.NavigateTo("/404");
        }
    }
}
