using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace DataEntity
{
    public class UserData
    {

        public CustomObject AddUser(UserObject userObject)
        {
            CustomObject customObject = new CustomObject();
            User user = new User()
            {
                Email = userObject.Email,
                Password = userObject.Password,
                FullName = userObject.FullName
            };
            BooksEntities booksEntities = new BooksEntities();
            booksEntities.User.Add(user);
            int value = booksEntities.SaveChanges();
            if(0 < value)
            {
                customObject.CustomMessage = "User Added Successfully!";
                customObject.CustomMessageNumber = value;
            }
            else
            {
                customObject.CustomMessage = "There is some problem adding User!";
                customObject.CustomMessageNumber = value;
            }
            return customObject;
        }

        public UserObject UserValidate(UserObject userObject)
        {
            bool isValid;
            BooksEntities booksEntities = new BooksEntities();
            UserObject user = null;
            using (booksEntities)
            {
                isValid = booksEntities.User.Any(x => x.Email == userObject.Email && x.Password == userObject.Password);
                if(isValid)
                {
                    user = booksEntities.User
                    .Where(x => x.Email == userObject.Email && x.Password == userObject.Password)
                    .Select(
                    x => new UserObject()
                    {
                        FullName = x.FullName,
                        Email = x.Email
                    }).FirstOrDefault();
                }
                return user;
            }
        }

        public bool IfUserExist(string email)
        {
            bool isValid;
            BooksEntities booksEntities = new BooksEntities();
            using (booksEntities)
            {
                isValid = booksEntities.User.Any(x => x.Email == email);
                return isValid;
            }
        }

    }
}
