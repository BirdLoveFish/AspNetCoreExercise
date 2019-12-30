using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationExercise
{
    public static class MemoryData
    {
        public static Dictionary<string, string> _dict = new Dictionary<string, string>
        {
            { "memorySection1", "value1" },
            { "memorySection2", "value2" },
        };
    }
}
