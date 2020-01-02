using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacExercise.Services
{
    public interface INameService
    {
        string Fun();
    }

    public class NameService : INameService
    {
        public string Fun()
        {
            return "Name Service";
        }
    }
}
