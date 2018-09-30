using System.Reflection;
using System.Web.Mvc;
using LearningMVC.Services;
using Ninject;

namespace LearningMVC.Controllers
{
    public class DI_TestController : Controller
    {
        public DI_TestController()
        {
        }
        // GET: DI_Test
        public ActionResult DI_Test()
        {
            ViewBag.DIData = DependencyInjectionTest();
            return View();
        }
        public string DependencyInjectionTest()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());            
            var dependencyInjectorService = kernel.Get<IDependencyInjectorService>();

            return dependencyInjectorService.DependencyInjectionTest();
        }
    }
}