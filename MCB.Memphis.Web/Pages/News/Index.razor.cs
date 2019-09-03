using MCB.Memphis.Core;
using MCB.Memphis.Core.Model;
using MCB.Memphis.Core.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Memphis.Web.Pages.News
{
    public class NewsIndexComponent : BasePage
    {
        protected bool ConfirmDialogVisible { get; set; }
        protected int ToDeleteNewsGuid { get; set; }

        [Inject]
        public INewsService _newsService { get; set; }
        [Inject]
        public IUriHelper _uriHelper { get; set; }
        [Inject]
        public AppStateProvider AppStateProvider { get; set; }

        protected List<NewsModel> newsList;
        protected override async Task OnInitializedAsync()
        {
            newsList = await _newsService.GetAllNewsAsync(AppStateProvider.SiteGuid);
            AppStateProvider.OnSiteGuidChanged += OnSiteGuidChanged;
        }

        private void OnSiteGuidChanged()
        {
            newsList = _newsService.GetAllNews(AppStateProvider.SiteGuid);
            StateHasChanged();
        }
        protected void ShowConfirmDialog(int newsGuid)
        {
            ToDeleteNewsGuid = newsGuid;
            ConfirmDialogVisible = true;
            StateHasChanged();

        }
        protected void HideConfirmDialog()
        {
            ToDeleteNewsGuid = 0;
            ConfirmDialogVisible = false;
            StateHasChanged();
        }
        protected void DeleteNews(int newsGuid)
        {
            _newsService.Delete(newsGuid);
            newsList = _newsService.GetAllNews(AppStateProvider.SiteGuid);
            HideConfirmDialog();
        }
    }
}

