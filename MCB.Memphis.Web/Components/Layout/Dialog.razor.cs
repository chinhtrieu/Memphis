using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Memphis.Web.Components.Layout
{
    public class DialogComponent : ComponentBase
    {
        [Parameter]
        public string HeadingText { get; set; }
        [Parameter]
        public string BodyText { get; set; }
        [Parameter]
        public string ConfirmText { get; set; }
        [Parameter]
        public string CancelText { get; set; }

        [Parameter]
        public EventCallback<UIMouseEventArgs> OnConfirm { get; set; }
        [Parameter]
        public EventCallback<UIMouseEventArgs> OnCancel { get; set; }
    }
}
