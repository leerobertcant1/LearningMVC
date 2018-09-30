using System.Collections.Generic;

namespace LearningMVC.Data.Web_Api
{
    public interface IUserRepository
    {
        IEnumerable<User> GetApiUsers();
    }
}