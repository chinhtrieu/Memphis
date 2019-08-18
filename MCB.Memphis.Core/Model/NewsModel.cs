using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Memphis.Core.Model
{
    public class NewsModel
    {
        public int NewsGuid { get; set; }
        public int SubGroupGuid { get; set; }
        public int SiteGuid { get; set; }

        public DateTime NewsStartDate { get; set; }
        public DateTime NewsEndDate {get;set;}

        public string NewsHeadline { get; set; }
        public string NewsManchet { get; set; }
        public string NewsText { get; set; }

        public string LogicalName { get; set; }

        public string PageTitle { get; set; }
        public string MetaDescription { get; set; }

        public string NewsKeywords { get; set; }
        public bool NewsHead { get; set; }
        public string NewsFreeTxt { get; set; }
    }
}
