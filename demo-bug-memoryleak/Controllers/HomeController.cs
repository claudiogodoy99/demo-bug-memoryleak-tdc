using demo_bug_memoryleak.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace demo_bug_memoryleak.Controllers
{
    public class Logs {
        public string message { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static List<string> logs = new List<string>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Enumerable.Range(0,1000)
                .ToList()
                .ForEach(x=> logs.Add("(xjf#;FT+QykNeJwd;Q@yPa//uRM37cy]Gc+wiBgK{$qQE{L83ncJg.JT8_uuYFjS]PQ,;S}LCJYi/Ydek5anT.,_t_bBPRf{;+G8EuyT/fVgjZHyQkXrVRMtZXnZQgU&,MX.X2,4r;{&&&?Q[-R}_H{X(g-tY2gZ9-m@zPMx]tG;J3wvD-4@Ye&z)qm_hdCNr-$)bXyF+UkGTrA!&:aQKridJncJ:CgPr[Q(9{NVQZEr&Ch-{%UN7?_Nd%pwxX6-C8,rPi%q)#XpYBBWDz:5ybj+m:)E)4Qjb+C{!@$$Wuh"))  ;

            return View();
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