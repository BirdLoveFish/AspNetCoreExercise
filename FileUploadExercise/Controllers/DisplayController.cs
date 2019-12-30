using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileExercise.Controllers
{
    public class DisplayController:Controller
    {

        public DisplayController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
