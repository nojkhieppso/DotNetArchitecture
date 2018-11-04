using Solution.CrossCutting.Utils;
using Solution.Model.Models;
using System.Collections.Generic;

namespace Solution.Application.Applications
{
    public interface IUserApplication
    {
        PagedList<UserModel> List(PagedListParameters parameters);

        IEnumerable<UserModel> List();

        UserModel Select(long userId);
    }
}
