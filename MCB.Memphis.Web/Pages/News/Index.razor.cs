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
        protected bool ConfirmDialogVisible { get; set; } = false;
        protected int ToDeleteNewsGuid { get; set; } = 0;

        [Inject]
        public INewsService _newsService { get; set; }
        [Inject]
        public IUriHelper _uriHelper { get; set; }

        protected List<NewsModel> newsList;        
        protected override async Task OnInitializedAsync()
        {
            newsList = await _newsService.GetAllNewsAsync(10535);
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
            newsList = _newsService.GetAllNews(10535);
            StateHasChanged();
        }
    }
}
