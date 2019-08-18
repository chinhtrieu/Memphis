#pragma checksum "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\Pages\News\Edit.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1ca4269a64be81bf8f7d8b7937f4e5832af3fb7"
// <auto-generated/>
#pragma warning disable 1591
namespace MCB.Memphis.Web.Pages.News
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
#line 2 "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\Pages\News\Edit.razor"
using MCB.Memphis.Web.Components;

#line default
#line hidden
#line 3 "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\Pages\News\Edit.razor"
using MCB.Memphis.Web.Components.News;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/news/{newsGuid:int}")]
    public class Edit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            builder.AddMarkupContent(0, "<div class=\"content-top stickable\">\r\n\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-12\">\r\n\r\n                \r\n                <div class=\"page-title-box hide-on-sticky\">\r\n                    <h1 class=\"page-title\">Add news</h1>\r\n                </div>\r\n\r\n                \r\n                <div class=\"page-actions page-actions--top\">\r\n                    <div class=\"row\">\r\n                        <div class=\"col col-relation\">\r\n                            <div class=\"btn-group\">\r\n                                <button type=\"button\" class=\"btn btn-dark btn-fn-general\" data-js-toggle-aria=\"tab-news-general\">General</button>\r\n\r\n                                \r\n                                \r\n                                <button type=\"button\" class=\"btn btn-default btn-fn-relation\" data-js-toggle-aria=\"tab-news-relations\">Relations<span class=\"badge badge-warning badge-dot\"></span></button>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col col-crud\">\r\n                            \r\n                            \r\n                            <button type=\"button\" class=\"btn btn-primary btn-icon btn-fn-addnew\"><i class=\"fe-plus-circle\"></i><span>New</span></button>\r\n                            <button type=\"button\" class=\"btn btn-default btn-icon btn-fn-delete\"><i class=\"fe-trash\"></i><span>Delete</span></button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                \r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            builder.AddMarkupContent(1, @"<div class=""content-main"">

    
    <div class=""container-fluid"">

        
        <div data-js-toggle=""tab-news-general"">
            <div class=""row"">
                <div class=""col-lg-6"">
                </div>

                <div class=""col-lg-6"">
                </div>
            </div>
        </div>


        
        <div data-js-toggle=""tab-news-relations"" style=""display: none"">
            <div class=""row"">
                <div class=""col-12"">
                    
                    <div class=""card-box card-box--relations"" style=""min-height: 300px"">
                        <div class=""card-box__title"">
                            <h5>News Relations</h5>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div> 

</div> 

");
            builder.AddMarkupContent(2, @"<div class=""content-bottom stickable"" data-js-toggle=""tab-news-general"">

    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""page-actions page-actions--bottom"">
                    <button type=""button"" class=""btn btn-default btn-fn-cancel"">Cancel</button>
                    <button type=""button"" class=""btn btn-primary btn-fn-submit"" disabled data-mcb-js-submit=""#form-general, #form-meta-data"">Save</button>
                </div>
            </div>
        </div>
    </div>

</div>");
        }
        #pragma warning restore 1998
#line 96 "E:\Workspace\MCB.Memphis\MCB.Memphis.Web\Pages\News\Edit.razor"
       
    [Parameter]
    public int NewsGuid { get; set; }

#line default
#line hidden
    }
}
#pragma warning restore 1591
