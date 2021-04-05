using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowlers.Models.ViewModels
{
    public class PageNumberingInfo
    {
        //fasciliates what we need for the automatic pagination
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        //Calculate the number of pages
        public int NumPages => (int)(Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage));
    }
}
