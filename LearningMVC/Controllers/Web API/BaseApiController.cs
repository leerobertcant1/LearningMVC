using LearningMVC.Data;
using LearningMVC.Data.Web_Api;
using LearningMVC.Models.Web_APIs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LearningMVC.Controllers.Web_API
{
    public abstract class BaseApiController : ApiController
    {
        private readonly IFoodRepository _foodsRepository;
        private readonly IUserRepository _userRepository;
        private readonly ModelFactory _modelFactory;

        public BaseApiController()
        {
            _foodsRepository = new FoodRepository();
            _userRepository = new UserRepository();

            _modelFactory = new ModelFactory(new HttpRequestMessage
            {
                RequestUri = new Uri("http://" + HttpContext.Current.Request.Url.Authority + "/" +
                                                 HttpContext.Current.Request.Url.AbsolutePath.Replace("/", " ").Trim().Replace(" ", "/"))
            });
        }

        public IFoodRepository FoodsRepository { get { return _foodsRepository; } }
        public IUserRepository UserRepository { get { return _userRepository;  } }

        public ModelFactory ModelFactory { get { return _modelFactory; } }
    }
}
