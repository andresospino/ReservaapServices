using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataConnection;

namespace Entities
{
    public class Restaurant
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

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        private string _Food;
        public string Food
        {
            get { return _Food; }
            set { _Food = value; }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _Schedule;
        public string Schedule
        {
            get { return _Schedule; }
            set { _Schedule = value; }
        }

        private string _Image;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

        private string _Price;
        public string Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        private string _Features;
        public string Features
        {
            get { return _Features; }
            set { _Features = value; }
        }

        private Int16 _Position;
        public Int16 Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        private string _State;
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        #endregion
        #region builders
        public Restaurant() { }
        public Restaurant(Int64 pId)
        {

        }
        public Restaurant(Int64 pId, string pName, string pAddress, string pFood, string pDescription, string pSchedule, string pImage, string pPrice, string pFeatures, Int16 pPosition, string pState)
        {
            _Id = pId;
            _Name = pName;
            _Address = pAddress;
            _Food = pFood;
            _Description = pDescription;
            _Schedule = pSchedule;
            _Image = pImage;
            _Price = pPrice;
            _Features = pFeatures;
            _Position = pPosition;
            _State = pState;
        }
        #endregion
        #region methods
        /// <summary>
        /// Get a list of the Restaurants depending position into of view application 
        /// </summary>
        /// <param name="pPosition">Value of Position</param>
        /// <returns>List of the restaurant</returns>
        public List<Restaurant> GetList(Int16 pPosition)
        {
            List<Restaurant> ListRestaurant = new List<Restaurant>();
            DataTable Data = new DataTable();
            StringBuilder Query = new StringBuilder();
            Query.AppendFormat("SELECT Id, Name, Address, Food, Description, Schedule, Image, Price, Features, Position, State FROM RESTAURANT WHERE position = {0} AND State = {1}", pPosition, "A");
            Dao Connection = new Dao();
            try
            {
                Data = Connection.ExecutSelect(Query.ToString());
                foreach (DataRow Row in Data.Rows)
                {
                    _Id = Convert.ToInt64(Row["Id"]);
                    _Name = Row["Name"].ToString();
                    _Address = Row["Address"].ToString();
                    _Food = Row["Food"].ToString();
                    _Description = Row["Description"].ToString();
                    _Schedule = Row["Schedule"].ToString();
                    _Image = Row["Image"].ToString();
                    _Price = Row["Price"].ToString();
                    _Features = Row["Features"].ToString();
                    _Position = Convert.ToInt16(Row["Position"]);
                    _State = Row["State"].ToString();
                }
            }
            catch { }
            return ListRestaurant;
        }
        #endregion
    }
}
