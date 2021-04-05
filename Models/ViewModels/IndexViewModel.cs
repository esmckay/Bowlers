using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowlers.Models.ViewModels
{
    //fascilitates what the info we need to pass into the controller
    public class IndexViewModel
    {
        public List<Bowlers> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string TeamName { get; set; }
    }
}
