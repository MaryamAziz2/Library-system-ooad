﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public bool forgetpassword(string username, string question, string answer)
        {
            bool isFound = false;
            foreach (User u in Userdl.user)
            {
                if (u.Username==username && u.SecretAnswer==answer)
                {
                    isFound = true;
                }
            }
            return isFound;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool isvalidAdmin(string username, string password)
        {
            bool isFound = false;
            Admin a = new Admin();
            if (username == a.username && password== a.password)
            {
                isFound = true;
            }
            return isFound;
        }

        public bool isvaliduser(string username, string password)
        {
            bool isFound = false;
            foreach (User u in Userdl.user)
            {
                if (u.Username == username && u.Password==password)
                {
                    isFound = true;
                }
            }
            return isFound;
        }

        public void registration(string username, string password, string q, string a)
        {
            User u = new User();
            u.Username = username;
            u.Password = password;
            u.SecretQuestion = q;
            u.SecretAnswer = a;
            Userdl.user.Add(u);
        }

        public void resetpassword(string username, string password)
        {
           foreach(User u in Userdl.user)
            {
                if(u.Username == username)
                {
                    u.Password = password;
                }
            }
        }
    }
}
