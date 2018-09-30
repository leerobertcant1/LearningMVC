using System.Collections.Generic;

namespace LearningMVC.Data.Web_Api
{
    public class UserRepository: IUserRepository
    {
        public IEnumerable<User> GetApiUsers()
        {
            return new List<User>()
            {
                new User { Username = "Lee@Lee.com", Password= "123" }
            };
        }
    }
}