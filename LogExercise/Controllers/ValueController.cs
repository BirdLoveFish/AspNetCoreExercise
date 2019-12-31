using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogExercise.Controllers
{
    public class ValueController: ControllerBase
    {
        private readonly IDiagnosticContext _diagnosticContext;

        public ValueController(IDiagnosticContext diagnosticContext)
        {
            _diagnosticContext = diagnosticContext 
                ?? throw new ArgumentNullException(nameof(diagnosticContext)); ;
        }

        public IActionResult Index()
        {
            //把某一项添加到日志中，不明白，还可以吧这个属性应用于全局
            _diagnosticContext.Set("CatalogLoadTime", 1423);

            return Ok("Value Index");
        }
    }
}
