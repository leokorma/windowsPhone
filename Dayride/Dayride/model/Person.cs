using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ParseHelloWorld.util;

namespace ParseHelloWorld.model
{
    public class Person
    {
        public static readonly string PARSE_CLASS_ID = "Person";

        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }

        public bool isAdmin()
        {
            return isRole(RoleUtils.ROLE_ADMIN);
        }

        public bool isTeacher()
        {
            return isRole(RoleUtils.ROLE_TEACHER);
        }

        public bool isStudent()
        {
            return isRole(RoleUtils.ROLE_STUDENT);
        }

        private bool isRole(string role)
        {
            return this.Role.Equals(role);
        }
    }
}
