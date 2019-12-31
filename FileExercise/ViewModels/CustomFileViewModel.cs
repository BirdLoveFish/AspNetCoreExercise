using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileExercise.ViewModels
{
    public class CustomFileViewModel
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
    }
}
