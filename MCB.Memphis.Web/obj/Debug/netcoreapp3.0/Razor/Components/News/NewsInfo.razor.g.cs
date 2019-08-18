#pragma checksum "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\Components\News\NewsInfo.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5abdb1cd693f9f262e079b60b6ddfc97bb5bae52"
// <auto-generated/>
#pragma warning disable 1591
namespace MCB.Memphis.Web.Components.News
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#line 3 "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 4 "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 5 "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\_Imports.razor"
using MCB.Memphis.Web;

#line default
#line hidden
#line 7 "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\_Imports.razor"
using MCB.Memphis.Web.Shared;

#line default
#line hidden
#line 1 "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\Components\_Imports.razor"
using MCB.Memphis.Web.Components;

#line default
#line hidden
    public class NewsInfo : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            builder.AddMarkupContent(0, "<div class=\"card-box card-box--form news-form news-form--general-info\" data-js-unwrap>\r\n    <div class=\"card-box__title\">\r\n        <h5>News information</h5>\r\n    </div>\r\n\r\n    <form class=\"needs-validation\" id=\"form-general\">\r\n\r\n        <div class=\"form-row form-row--group-date\">\r\n            <div class=\"form-group form-group--startdate col\">\r\n                <div class=\"form-group__label\">\r\n                    <label for=\"field-start-date\">Start date</label>\r\n                </div>\r\n\r\n                <div class=\"form-group__controls\">\r\n                    \r\n                    <input class=\"form-control\" data-plugin=\"flatpickr\" id=\"field-start-date\" name=\"startdate\" placeholder=\"Start date\" type=\"date\">\r\n                    <div class=\"invalid-feedback\">\r\n                        Start date must be ealier than End date.\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"form-group form-group--enddate col\">\r\n                <div class=\"form-group__label\">\r\n                    <label for=\"field-end-date\">End date</label>\r\n                </div>\r\n\r\n                <div class=\"form-group__controls\">\r\n                    \r\n                    <input class=\"form-control\" data-plugin=\"flatpickr\" id=\"field-end-date\" name=\"enddate\" placeholder=\"End date\" type=\"date\">\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group form-group--headline\">\r\n            <div class=\"form-group__label\">\r\n                <label for=\"field-headline\">Headline</label>\r\n            </div>\r\n            <div class=\"form-group__controls\">\r\n                <input type=\"text\" id=\"field-headline\" name=\"headline\" class=\"form-control\" placeholder=\"Enter headline\" max-length=\"255\">\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group form-group--optional-link\">\r\n            <div class=\"form-group__label\">\r\n                <label for=\"field-link\">Optional link</label>\r\n            </div>\r\n            <div class=\"form-group__controls\">\r\n                <input type=\"url\" id=\"field-optional-link\" name=\"optionallink\" class=\"form-control\" placeholder=\"Enter optional link\" maxlength=\"250\">\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group form-group--manchet\">\r\n            <div class=\"form-group__label\">\r\n                <label for=\"field-Manchet\">Manchet</label>\r\n            </div>\r\n            <div class=\"form-group__controls\">\r\n                <textarea class=\"form-control\" id=\"field-manchet\" name=\"manchet\" rows=\"3\" placeholder=\"Enter manchet\" maxlength=\"1000\"></textarea>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group form-group--text\">\r\n            <div class=\"form-group__label\">\r\n                <label for=\"field-description\">Text</label>\r\n            </div>\r\n            <div class=\"form-group__controls\">\r\n                <textarea class=\"form-control\" data-plugin=\"summernote\" rows=\"3\" id=\"field-description\" name=\"text\" placeholder=\"Enter Text\">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse eu interdum augue, non lobortis purus. Nulla posuere blandit egestas. Etiam dignissim odio</textarea>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group form-group--groups\">\r\n            <div class=\"form-group__label\">\r\n                <label for=\"field-category\">Groups</label>\r\n            </div>\r\n            <div class=\"form-group__controls\">\r\n                <select class=\"form-control selectpicker\" id=\"field-category\" name=\"groups\" data-live-search=\"true\" data-size=\"20\" data-style=\"btn-default\">\r\n                    <option>Select group</option>\r\n                    <option value=\"SH1\">Danish</option>\r\n                    <option value=\"SH4\">Danish frontpage</option>\r\n                    <option value=\"SH2\">English</option>\r\n                    <option value=\"SH3\">Finnish</option>\r\n                </select>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group form-group--topnews\">\r\n            <div class=\"form-group__label\">\r\n                <label>Top news</label>\r\n            </div>\r\n            <div class=\"form-group__controls\">\r\n                <div class=\"custom-control custom-switch\">\r\n                    <input type=\"checkbox\" class=\"custom-control-input\" id=\"topnewsRadio\" name=\"topnews\">\r\n                    <label class=\"custom-control-label\" for=\"topnewsRadio\">Enabled</label>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group form-group--freetext\">\r\n            <div class=\"form-group__label\">\r\n                <label for=\"field-free-text\">Free text</label>\r\n            </div>\r\n            <div class=\"form-group__controls\">\r\n                <textarea class=\"form-control\" data-plugin=\"summernote\" rows=\"3\" id=\"field-free-text\" name=\"freetext\" placeholder=\"Enter free text\"></textarea>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>\r\n\r\n");
            builder.AddMarkupContent(1, "<div class=\"card-box card-box--form news-form news-form--general-seo\" data-js-unwrap>\r\n    <div class=\"card-box__title\">\r\n        <h5>SEO</h5>\r\n    </div>\r\n\r\n    <form class=\"needs-validation\" id=\"form-meta-data\">\r\n        <div class=\"form-group form-group--searchwords\">\r\n            <div class=\"form-group__label\">\r\n                <label for=\"field-meta-title\">Search words</label>\r\n            </div>\r\n            <div class=\"form-group__controls\">\r\n                <input type=\"text\" class=\"form-control\" id=\"field-search-words\" name=\"searchwords\" placeholder=\"Comma-separated list of keywords on the page where the product should be found\">\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group form-group--titletag\">\r\n            <div class=\"form-group__label\">\r\n                <label for=\"field-meta-title\">Title tag</label>\r\n            </div>\r\n            <div class=\"form-group__controls\">\r\n                <input type=\"text\" class=\"form-control\" id=\"field-meta-title\" name=\"titletag\" placeholder=\"Can be used to set a different title tag than the name of the item\">\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group form-group--metadescription\">\r\n            <div class=\"form-group__label\">\r\n                <label for=\"field-meta-description\">Meta Description</label>\r\n            </div>\r\n            <div class=\"form-group__controls\">\r\n                <textarea class=\"form-control\" id=\"field-meta-description\" name=\"metadescription\" rows=\"3\" placeholder=\"Short description intended for search engines. High probability of appearing in search results. We recommend a maximum of 250 characters\" maxlength=\"250\">Lorem ipsum dolor sit amet, consectetur adipiscing elit</textarea>\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group form-group--metakeywords\">\r\n            <div class=\"form-group__label\">\r\n                <label for=\"field-meta-keywords\">Meta Keywords</label>\r\n            </div>\r\n            <div class=\"form-group__controls\">\r\n                <textarea class=\"form-control\" id=\"field-meta-keywords\" name=\"metakeywords\" rows=\"3\" placeholder=\"Comma-separated list of the most relevant keywords on the page. We recommend a maximum of 10 words. Can be used to list words misspelled, e.g. `Triumph, Triumph`\" maxlength=\"200\"></textarea>\r\n            </div>\r\n        </div>\r\n    </form>\r\n</div>");
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591