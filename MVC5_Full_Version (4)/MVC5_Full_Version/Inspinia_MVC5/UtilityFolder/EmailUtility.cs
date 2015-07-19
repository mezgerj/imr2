using Inspinia_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Inspinia_MVC5.UtilityFolder {
    public static class EmailUtility
    {
        private const string ConfirmTitle = "Confirmation from IMR_Framwork";
        private const string ApproveTitle = "Registration request has been Approved from IMR_Framwork";
        private const string DeclineTitle = "Registration request has been Declined from IMR_Framework";
        private const string AdminTitle = "Admin Account Infomation from IMR_Framework";
        private const string UserCreationTitle = "User Account Created by IMR_Framework";
        private const string PasswordResetTitle = "User Password Reset by IMR_Framework";
        public static void SendConfirmEmail(string emailAddress)
        {
            //WebMail.EnableSsl = true;
            WebMail.EnableSsl = false;
            WebMail.Send(emailAddress, ConfirmTitle, "This is automated email sent from IMR_Framework for confirmation.");
        }

        public static void SendApproveEmail(string emailAddress)
        {
            //WebMail.EnableSsl = true;
            WebMail.EnableSsl = false;
            WebMail.Send(emailAddress, ApproveTitle, "Your company has been approved");
        }

        public static void SendDeclineEmail(string emailAddress)
        {
            //WebMail.EnableSsl = true;
            WebMail.EnableSsl = false;
            WebMail.Send(emailAddress, DeclineTitle, "Your company has been declined");
        }

        public static void SendAdminEmail(string emailAddress, string lastName, string userName, string passsword)
        {
            //WebMail.EnableSsl = true;
            WebMail.EnableSsl = false;
            WebMail.Send(emailAddress, AdminTitle, "Dear Mr/Mrs. " + lastName + "<br />Your username: " + userName + "<br />Your Password: " + passsword);
        }

        public static void SendUserCreationEmail(string emailAddress, string lastName, string userName, string passsword)
        {
            string method = "SendUserCreationEmail";
            var entry = findMessage(method);
            string message = "";
            
            //Since entry is iterabale of SQL objects I just used a foreach loop to get the item properity even though there will only be on SQL object. 
            foreach (var obj in entry)
            {
                message = obj.Item;
            }

            //Used to split up the item string so I can insert the given lastName, userName, and password.
            char[] delimiters = { '+', ' '};
            string[] parsed = message.Split(delimiters);
            string send = "";

            //How the string is put back together to use the given parameters.
            for (int count = 0; count < parsed.Length; count++)
            {
                if (parsed[count].Equals("lastName"))
                {
                    send += lastName + " ";
                }
                else if (parsed[count].Equals("userName"))
                {
                    send += userName + " ";
                }
                else if (parsed[count].Equals("passsword"))
                {
                    send += passsword + " ";
                }
                else if (parsed[count].Equals("(newLine)"))
                {
                    send += "<br/>";
                }
                else
                {
                    send += parsed[count] + " ";
                }
            }
                //WebMail.EnableSsl = true;
                WebMail.EnableSsl = false;
                WebMail.Send(emailAddress, UserCreationTitle, send);
         
        }

        public static void SendPasswordResetEmail(string emailAddress, string lastName, string userName,
            string passsword)
        {
            WebMail.EnableSsl = false;
            WebMail.Send(emailAddress, PasswordResetTitle, "Dear Mr/Mrs. " + lastName +
                "<br />Your Password has been created <br /> Your username: " + userName +
                "<br />Your Password: " + passsword
                + "<br />Please visit our website at https://imr.azurewebsites.net to login.<br />"
            + "Developers should visit https://imr-api.azurewebsites.net for informaiton on how to use the API.");
        }

        //Finds the item from the database of the given method.
        public static IQueryable<Utility> findMessage(string method)
        {
            ScaffoldingContext db = new ScaffoldingContext();
            return from entry in db.Utilities
                   where entry.Method.Equals(method)
                   select entry;
        }
    }
}