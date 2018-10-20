namespace LearningMVC.Services
{
    public class DependencyInjectorService: IDependencyInjectorService
    {
        public string DependencyInjectionTest()
        {
            return "Dependency Injector test";
        }

        public void DependencyInjectionAttributeTest(bool set)
        {
            set = true;
        }
    }
}