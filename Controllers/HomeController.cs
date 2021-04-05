using Bowlers.Models;
using Bowlers.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bowlers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        //Pass in teamid, name and default pagenum into the controller
        public IActionResult Index(long? teamid, string teamname, int pageNum = 0)
        {
            int pageSize = 5;

            //set what we need out of the indexviewmodel
            return View(new IndexViewModel
            {
                Bowlers = context.Bowlers
                .Where(b => b.TeamId == teamid || teamid == null)
                .OrderBy(b => b.BowlerFirstName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList(),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,

                    //If no team has been selected then return all bowlers, otherwise just return the bowlers on that specific team
                    TotalNumItems = (teamid == null ? context.Bowlers.Count() : 
                        context.Bowlers.Where(x=> x.TeamId == teamid).Count())
                },

                TeamName = teamname
            });
                
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
