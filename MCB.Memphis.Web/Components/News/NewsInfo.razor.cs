using MCB.Memphis.Core.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Memphis.Web.Components.News
{
    public class NewsInfoComopnent : ComponentBase
    {
        [Parameter]
        public NewsModel NewsModel { get; set; }


    }
}
