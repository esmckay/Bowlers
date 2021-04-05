using Bowlers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//View component for the bowling teams. 
namespace Bowlers.Components
{
    public class BowlerTeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public BowlerTeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];

            return View(context.Teams
                .Distinct()
                .OrderBy(x=>x));
        }
    }
}
