using LearningMVC.Services;

namespace LearningMVC.Data
{
    public class DI_Repostitory
    {
        IDependencyInjectorService _di;
        public DI_Repostitory(IDependencyInjectorService di)
        {
            _di = di;
        }

        public string GetData()
        {
            return _di.DependencyInjectionTest();
        }

        public void SetData(bool set)
        {
            _di.DependencyInjectionAttributeTest(set);
        }
    }
}

//Jenkins test
