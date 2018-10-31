using Microsoft.AspNetCore.Mvc;
using Solution.Application.Applications;
using Solution.CrossCutting.AspNetCore.Attributes;
using Solution.Model.Models;
using System.Collections.Generic;

namespace Solution.Web.App
{
    [ApiController]
    [RouteController]
    public class UsersController : ControllerBase
    {
        public UsersController(IUserApplication userApplication)
        {
            UserApplication = userApplication;
        }

        private IUserApplication UserApplication { get; }

        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return UserApplication.List();
        }

        [HttpGet("{id}")]
        public UserModel Get(long id)
        {
            return UserApplication.Select(id);
        }
    }
}
