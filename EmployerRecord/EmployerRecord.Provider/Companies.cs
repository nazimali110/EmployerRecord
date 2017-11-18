using EmployerRecord.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployerRecord.Common;

namespace EmployerRecord.Provider
{
    public class Companies
    {
        //public static List<Company> Get()
        //{
        //    return new List<Company>();
        //}
        //public static List<Company> Get(int pageNumber)
        //{
        //    return Get(pageNumber, 10);
        //}
        //public static List<Company> Get(int pageNumber, int pageSize)
        //{
        //    int totalCount;
        //    return Get(pageNumber, pageSize, out totalCount);
        //}
        ////public static List<Company> Get(int pageNumber, int pageSize, out int totalCount)
        ////{
        ////    totalCount = 0;
        ////    return Get(pageNumber, pageSize, out totalCount, 0);
        ////}
        //public static List<Company> Get(int pageNumber, int pagesize, out int totalCount)
        //{
        //    return Get(pageNumber, pagesize, out totalCount, 1, string.Empty);
        //}
        //public static List<Company> Get(int pageNumber, int pageSize, out int totalCount, int status, string keyword)
        //{
        //    totalCount = 0;
        //    List<Company> items = null;

        //    using (SqlConnection connection = Common.Helper.Connection)
        //    {
        //        SqlCommand command = new SqlCommand("SelectCompany", connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@pageNumber", pageNumber);
        //        command.Parameters.AddWithValue("@pageSize", pageSize);
        //        command.Parameters.AddWithValue("@status", status);
        //        command.Parameters.AddWithValue("@fillterKey", keyword);
        //        connection.Open();

        //        using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
        //        {
        //            items = new List<Company>();
        //            while (reader.Read())
        //            {
        //                Company item = GetFromReader(reader);
        //                items.Add(item);
        //            }

        //            if (reader.NextResult())
        //            {
        //                while (reader.Read())
        //                {
        //                    totalCount = reader.GetInt32(0);
        //                }
        //            }
        //        }
        //    }

        //    return items;
        //}
        //public static List<Company> GetReport(int status, string keyword)
        //{
        //    List<Company> items = null;

        //    using (SqlConnection connection = Common.Helper.Connection)
        //    {
        //        SqlCommand command = new SqlCommand("SelectCompanyReport", connection);
        //        command.CommandType = CommandType.StoredProcedure;

        //        command.Parameters.AddWithValue("@status", status);
        //        command.Parameters.AddWithValue("@fillterKey", keyword);
        //        connection.Open();

        //        using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
        //        {
        //            items = new List<Company>();
        //            while (reader.Read())
        //            {
        //                Company item = GetFromReader(reader);
        //                items.Add(item);
        //            }
        //        }
        //    }
        //    return items;
        //}
        #region Get
        
        
        public static Company GetById(int id)
        {
            Company item = new Company();
            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand command = new SqlCommand("SelectCompanyById", connection);//SelectRegisterInterestById needed to create
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {

                    while (reader.Read())
                    {
                        item = GetFromReader(reader);
                    }
                }
            }
            return item;
        }
        public static Company GetByUserPass(string username,string password)
        {
            Company item = new Company();
            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand command = new SqlCommand("SelectCompanyByUserPass", connection);//SelectRegisterInterestById needed to create
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {

                    while (reader.Read())
                    {
                        item = GetFromReader(reader);
                    }
                }
            }
            return item;
        }
        public static List<Company> GetAll()
        {
            List<Company> items = null;
            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand command = new SqlCommand("SelectCompany", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    items = new List<Company>();
                    while (reader.Read())
                    {
                        //if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                        //{
                        //    string item = reader.GetString(reader.GetOrdinal("Name"));
                        //    items.Add(item);
                        //}
                        Company item = GetFromReader(reader);
                        items.Add(item);
                    }
                }
            }

            return items;

        }

        #endregion

        #region Add
        /// <summary>
        ///  This method is used to Add user from facebook profile
        /// </summary>
        /// <param name="facebookId"></param>
        /// <param name="facebookProfileUrl"></param>
        /// <param name="profilePictureUrl"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="country"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        /// 
        public static Int32 Add(Company item)
        {

            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertCompany";
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Phone", item.Phone);
                cmd.Parameters.AddWithValue("@pin", item.pin);
                cmd.Parameters.AddWithValue("@Qrcode", item.Qrcode);
               // cmd.Parameters.AddWithValue("@email", item.email);
               // cmd.Parameters.AddWithValue("@DateCreated", item.DateCreated);
               // cmd.Parameters.AddWithValue("@Status", item.Status);
                cmd.Parameters.AddWithValue("@username", item.username);
                cmd.Parameters.AddWithValue("@password", item.password);
                connection.Open();

                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        #endregion

        #region Update
        /// <summary>
        ///  This method is used to Add user from facebook profile
        /// </summary>
        /// <param name="facebookId"></param>
        /// <param name="facebookProfileUrl"></param>
        /// <param name="profilePictureUrl"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="country"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        /// 
        public static Int32 Update(Company item)
        {

            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateCompany";
                cmd.Parameters.AddWithValue("@Id", item.Id);
             //   cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Phone", item.Phone);
                cmd.Parameters.AddWithValue("@pin", item.pin);
            //    cmd.Parameters.AddWithValue("@Qrcode", item.Qrcode);
              //  cmd.Parameters.AddWithValue("@email", item.email);
                // cmd.Parameters.AddWithValue("@DateCreated", item.DateCreated);
                // cmd.Parameters.AddWithValue("@Status", item.Status);
            //    cmd.Parameters.AddWithValue("@username", item.username);
                cmd.Parameters.AddWithValue("@password", item.password);
                cmd.Parameters.AddWithValue("@Status", item.Status);
                connection.Open();

                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        #endregion
        public static Company GetFromReader(SqlDataReader dr)
        {
            Company item = new Company();

            item.Id = dr.GetInt32(dr.GetOrdinal("Id"));

            if (!dr.IsDBNull(dr.GetOrdinal("Name")))
                item.Name = dr.GetString(dr.GetOrdinal("Name"));
           // if (!dr.IsDBNull(dr.GetOrdinal("email")))
           //     item.email = dr.GetString(dr.GetOrdinal("email"));
            if (!dr.IsDBNull(dr.GetOrdinal("password")))
                item.password = dr.GetString(dr.GetOrdinal("password"));
            if (!dr.IsDBNull(dr.GetOrdinal("Phone")))
                item.Phone = dr.GetString(dr.GetOrdinal("Phone"));
            if (!dr.IsDBNull(dr.GetOrdinal("pin")))
                item.pin = dr.GetString(dr.GetOrdinal("pin"));
            if (!dr.IsDBNull(dr.GetOrdinal("Qrcode")))
                item.Qrcode = dr.GetString(dr.GetOrdinal("Qrcode"));
            if (!dr.IsDBNull(dr.GetOrdinal("username")))
                item.username = dr.GetString(dr.GetOrdinal("username"));       
            if (!dr.IsDBNull(dr.GetOrdinal("Status")))
                item.Status = dr.GetInt32(dr.GetOrdinal("Status"));
            if (!dr.IsDBNull(dr.GetOrdinal("DateCreated")))
                item.DateCreated = dr.GetDateTime(dr.GetOrdinal("DateCreated"));

            return item;
        }
    }
}
