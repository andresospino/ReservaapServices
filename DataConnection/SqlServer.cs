using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConnection
{
    public class Dao
    {
        #region propyerties
        private SqlConnection _Connection;
        public SqlConnection Connection
        {
            get
            {
                return _Connection;
            }
            set
            {
                _Connection = value;
            }
        }
        #endregion
        #region builds
        public Dao()
        {
            try
            {
                string StringConnection = "Server=Cristian-PC\\SQLEXPRESS;Database=CulturizaMe;Trusted_Connection=True;";
                _Connection = new SqlConnection(StringConnection);
                _Connection.Open();
            }
            catch { }
        }
        #endregion
        #region methods
        /// <summary>
        /// Para Consultas Read
        /// </summary>
        /// <param name="pSelect">Consulta</param>
        /// <returns>Registros encontrados</returns>
        public DataTable ExecutSelect(string pSelect)
        {
            DataTable vDt = new DataTable();
            try
            {
                SqlCommand vQuery = new SqlCommand(pSelect, _Connection);
                SqlDataReader vDr = vQuery.ExecuteReader();
                vDt.Load(vDr);
                _Connection.Close();
            }
            catch { _Connection.Close(); }
            return vDt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pQuery"></param>
        /// <returns></returns>
        public int ExecuteInsertUpdate(string pQuery)
        {
            int Result = 0;
            try
            {
                SqlCommand vQuery = new SqlCommand(pQuery, _Connection);
                Result = vQuery.ExecuteNonQuery();
                _Connection.Close();
            }
            catch
            {
                _Connection.Close();
            } 
            return Result;
        }
        #endregion
        /// <summary>
        /// Abre la conexion a la BD
        /// </summary>
        
    }
}
