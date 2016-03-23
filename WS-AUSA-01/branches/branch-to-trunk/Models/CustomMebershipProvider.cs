using System.Web.Security;
using System;
using System.Security.Cryptography;
using System.Text;
using MvcAppRest.Controllers;
using MvcAppRest.WsAusa;
using System.IO;


namespace MvcAppRest.Models
{
    //http://www.codeproject.com/Articles/165159/Custom-Membership-Providers
    public class CustomMembershipProvider : MembershipProvider
    {
        private string result;
        public string Result() { return result; }

        public override bool ValidateUser(string username, string password)
        {
            //string sha1Pswd = GetMD5Hash(password);

            //PUT LOGIC TO AUTHENTICATE
            WS_SVUSoapClient srAusa = new WsAusa.WS_SVUSoapClient();
            string resultado = srAusa.nuevaAutenticacion(username, password);
            
            if (!string.IsNullOrEmpty(resultado))
            {
               // WriteLog(username, password, resultado, true);               
                result = resultado;
                return resultado.IndexOf(';') != 0;
            }
            else
            {
               // WriteLog(username, password, resultado, false); 
                return false;
            }
        }

        private void WriteLog(string username, string password, string resultado, bool isAuthenticated) 
        {
            string logeado = "Logeado exitosamente.";
            string notlogeado = "Logeado erroneamente";
            string cadena;
            string path = System.IO.Directory.GetCurrentDirectory(); 
            string fileName = Path.Combine(path, String.Format("log_{0}.txt", DateTime.Now));

            if (isAuthenticated)
                cadena = logeado;
            else
                cadena = notlogeado;

            string text = "STATUS: " + cadena + ", \n" +
                           "User logged: " + username + ", \n" +
                          "Password logged: " + password + ", \n" +
                          "Resultado: " + resultado + ", \n" +
                   " at . " + DateTime.Now.ToString();
            System.IO.File.WriteAllText(fileName, text);
        }

        public static string GetMD5Hash(string value)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override bool RequiresUniqueEmail
        {
            // In a real application, you will essentially have to return true
            // and implement the GetUserNameByEmail method to identify duplicates
            get { return false; }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
    }
}