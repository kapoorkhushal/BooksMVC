using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Business;
using FluentValidation.Results;

namespace BusinessFacade
{
    public class UserBusinessLogic
    {
        BusinessUser businessUser;
        public UserBusinessLogic()
        {
            businessUser = new BusinessUser();
        }
        public ValidationResult AddUser(UserObject userObject)
        {
            return businessUser.AddUser(userObject);
        }

        public UserObject UserValidate(UserObject userObject)
        {
            UserObject user = businessUser.UserValidate(userObject);
            return user;
        }
    }
}
