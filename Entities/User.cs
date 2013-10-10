using System;
using System.Data;
using System.Text;
using DataConnection;
namespace Entities
{
    public class User
    {
        #region propertys
        private Int64 _Id;
        public Int64 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Mail;
        public string Mail
        {
            get { return _Mail; }
            set { _Mail = value; }
        }
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        private string _Country;
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        private string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        private string _Facebook;
        public string Facebook
        {
            get { return _Facebook; }
            set { _Facebook = value; }
        }
        private string _Twitter;
        public string Twitter
        {
            get { return _Twitter; }
            set { _Twitter = value; }
        }
        private string _Image;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
        private string _State;
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        #endregion
        #region builders
        public User() { }
        public User(Int64 pId, string pName, string pMail, string pUserName, string pPassword, string pCountry, string pCity, string pFacebook, string pTwitter, string pImage, string pState)
        {
            _Id = pId;
            _Name = pName;
            _Mail = pMail;
            _UserName = pUserName;
            _Password = pPassword;
            _Country = pCountry;
            _City = pCity;
            _Facebook = pFacebook;
            _Twitter = pTwitter;
            _Image = pImage;
            _State = pState;
        }
        #endregion
        #region methods
        /// <summary>
        ///  create a new user into application
        /// </summary>
        /// <param name="pName">User's nickname </param>
        /// <param name="pMail">User's email</param>
        /// <param name="pPassword">User's password encoded Base64</param>
        /// <returns>true, if is successful</returns>
        public bool Register(string pName, string pMail, string pPassword)
        {
            StringBuilder Query = new StringBuilder();
            Query.AppendFormat("INSERT INTO USER (name, mail, password, state) VALUES ({0},{1},{2},{3})", pName, pMail, pPassword, "A");
            Dao Connection = new Dao();
            int Result = Connection.ExecuteInsertUpdate(Query.ToString());
            return (Result == 1)?true:false;
        }
        /// <summary>
        ///  check if exits a user into application
        /// </summary>
        /// <param name="pMail">User's email</param>
        /// <param name="pPassword">User's password encoded Base64</param>
        /// <returns>true, if is successful</returns>
        public bool Login(string pMail, string pPassword)
        {
            StringBuilder Query = new StringBuilder();
            DataTable Data = new DataTable();
            bool Result = false;
            Query = Query.AppendFormat("SELECT Id, name, username, country, city, facebook, twitter, image, state FROM USER WHERE mail = {0} AND password = {1}", pMail, pPassword);
            Dao Connection = new Dao();
            try
            {
                Data = Connection.ExecutSelect(Query.ToString());
                foreach (DataRow Row in Data.Rows)
                {
                    _Id = Convert.ToInt64(Row["Id"]);
                    _Name = Row["name"].ToString();
                    _UserName = Row["username"].ToString();
                    _Country = Row["country"].ToString();
                    _City = Row["city"].ToString();
                    _Facebook = Row["facebook"].ToString();
                    _Twitter = Row["twitter"].ToString();
                    _Image = Row["image"].ToString();
                    _State = Row["state"].ToString();
                }
                Result = true;
            }
            catch
            { Result = false; }
            return Result;
        }
        /// <summary>
        /// Save and Update the user's  profile data
        /// </summary>
        /// <returns>true, if is successful</returns>
        public bool Save()
        {
            StringBuilder Query = new StringBuilder();
            Query.AppendFormat(" UPDATE USER SET name = {0}, UserName = {1}, state= {2}, password = {3}, country = {4}, city = {5}, facebook = {6}, twitter = {7}, image = {8} ", _Name, _UserName, _State, _Password, _Country, _City, _Facebook, _Twitter, _Image);
            Query.AppendFormat(" WHERE mail = {0} AND Id = {1}", _Mail, _Id);
            Dao Connection = new Dao();
            int Result = Connection.ExecuteInsertUpdate(Query.ToString());
            return (Result == 1) ? true : false;
        }
        #endregion
    }
}
