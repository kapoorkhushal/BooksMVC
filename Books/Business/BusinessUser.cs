using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Web;
using Shared;
using DataEntity;

namespace Business
{
    public class BusinessUser
    {
        UserData userData;
        UserValidator userValidator;
        public BusinessUser()
        {
            userData = new UserData();
            userValidator = new UserValidator();
        }

        public ValidationResult AddUser(UserObject userObject)
        {
            if(userData.IfUserExist(userObject.Email))
            {
                return null;
            }
            ValidationResult result = userValidator.Validate(userObject);
            if(result.IsValid)
            {
                CustomObject customObject = userData.AddUser(userObject);
            }
            return result;
        }

        public UserObject UserValidate(UserObject userObject)
        {
            UserObject user = userData.UserValidate(userObject);
            return user;
        }
    }
}
