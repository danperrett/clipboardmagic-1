using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clipboardmagic
{
    public class User
    {
        public string Username;
        public string Password;
    }
    public class UserCredentialsStore
    {
        private User credentials = new User();
        private bool m_valid = false;
        public static UserCredentialsStore instance = null;

        public User Credentials
        {
            get
            {
                return credentials;
            }

            set
            {
                credentials = value;
            }
        }

        public string Username
        {
            get
            {
                return credentials.Username;
            }
            set
            {
                credentials.Username = value;
            }
        }

        public string getPassword(int randomAccess)
        {
            return encodePassword(Username, credentials.Password, randomAccess);
        }
        
        
        public string Password
        {
           
            get
            {
                return credentials.Password;
            }
            set
            {
                credentials.Password = value;
            }
        }

        public bool Valid
        {
            get
            {
                return m_valid;
            }

            set
            {
                m_valid = value;
            }
        }

        public static UserCredentialsStore GetInstance()
        {
            if(instance == null)
            {
                instance = new UserCredentialsStore();
            }

            return instance;
        }

        private UserCredentialsStore()
        {
            m_valid = false;
        }

        private string encodePassword(string username, string password, int randomcode)
        {
            string pass = "";
            byte rr = (byte)(randomcode & 0xFF);
            try
            {
                int i = 0;
                char[] _username = username.ToCharArray();
                char[] _password = password.ToCharArray();
                byte[] data = new byte[_password.Length];

                for (int n = 0; n < data.Length; n++)
                {
                    data[n] = (byte)((byte)_password[n] ^ (byte)_username[i++] ^ rr);
                    if (i == _username.Length)
                    {
                        i = 0;
                    }
                }
                pass = Convert.ToBase64String(data);
            }
            catch (Exception ex)
            {

            }

            return pass;
        }

    }
}
