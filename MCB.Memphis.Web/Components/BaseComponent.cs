﻿using MCB.Memphis.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Memphis.Web.Components
{
    public class BaseComponent : ComponentBase
    {
        [Inject] public AppStateProvider AppStateProvider { get; set; }

    }
}
