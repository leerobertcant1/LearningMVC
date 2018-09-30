using Ninject.Modules;
using Ninject;
using LearningMVC.Services;
using System.Reflection;
using LearningMVC.Data;

namespace LearningMVC.Dependency_Injection
{
    public class NinjectBindings: NinjectModule
    {
        public  override void Load()
        {
            Bind<IDependencyInjectorService>().To<DependencyInjectorService>();
            Bind<IFoodRepository>().To<FoodRepository>();
        }

        public IFoodRepository GetFoodRepository()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            return kernel.Get<IFoodRepository>();
        }
    }
}