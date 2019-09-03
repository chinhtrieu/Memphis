using MCB.Memphis.Core;
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
    public class NewsEditComponent : BasePage
    {
        [Inject]
        public INewsService _newsService { get; set; }

        [Inject]
        public IUriHelper _uriHelper { get; set; }

        [Parameter]
        public int NewsGuid { get; set; }

        [Inject]
        public AppStateProvider AppStateProvier { get; set; }

        protected NewsModel newsModel;
       
        protected override async Task OnInitializedAsync()
        {
            AppStateProvier.OnSiteGuidChanged += OnSiteGuidChanged;

            if (NewsGuid > 0)
            {
                newsModel = await _newsService.GetNewsAsync(NewsGuid);
            }
            else
            {
                newsModel = new NewsModel();
            }
            if(newsModel == null) _uriHelper.NavigateTo("/404");
        }

        private void OnSiteGuidChanged()
        {
            _uriHelper.NavigateTo("/news");
        }

        protected void SaveNews()
        {
            _newsService.SaveNews(newsModel);
            _uriHelper.NavigateTo("/news");
        }
    }
}
