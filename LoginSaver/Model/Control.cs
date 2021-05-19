using LoginSaver.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSaver.Model
{
    public class Control
    {
        public bool valid;
        public String message = "";

        public bool Access(String login, String password)
        {
            LoginDaoCommands loginDao = new LoginDaoCommands();
            valid = loginDao.VerifyLogin(login, password);
            if(! loginDao.message.Equals(""))
            {
                this.message = loginDao.message;
            }
            return valid;
        }

        public String Register(String email, String password, String confPass)
        {
            LoginDaoCommands loginDao = new LoginDaoCommands();
            loginDao.Register(email, password, confPass);
            if (loginDao.valid)
            {
                this.valid = true;
            }
            return message;
        }
    }
}
