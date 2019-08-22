
using Microsoft.AspNetCore.Components;
using System;

namespace MCB.Memphis.Web.Components.Layout
{
    public class ConfirmDialogComponent : ComponentBase
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
        public Action OnConfirm { get; set; }
        [Parameter]
        public Action OnCancel { get; set; }
    }
}
