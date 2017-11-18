using EmployerRecord.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployerRecord.Provider
{
    public class Employees
    {
        #region Get


        public static Employee GetById(int id)
        {
            Employee item = new Employee();
            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand command = new SqlCommand("SelectEmployeeById", connection);//SelectRegisterInterestById needed to create
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
        public static Employee GetByUserPass(string username, string password)
        {
            Employee item = new Employee();
            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand command = new SqlCommand("SelectEmployeeByUserPass", connection);//SelectRegisterInterestById needed to create
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
        public static List<Employee> GetAll()
        {
            List<Employee> items = null;
            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand command = new SqlCommand("SelectEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    items = new List<Employee>();
                    while (reader.Read())
                    {
                        Employee item = GetFromReader(reader);
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
        public static Int32 Add(Employee item)
        {

            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertEmployee";
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Contact", item.Contact);
                cmd.Parameters.AddWithValue("@CompanyId", item.CompanyId);
                cmd.Parameters.AddWithValue("@hourrate", item.hourrate);
               
                cmd.Parameters.AddWithValue("@password", item.password);
                cmd.Parameters.AddWithValue("@username", item.username);
                cmd.Parameters.AddWithValue("@active", item.active);
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
        public static Int32 Update(Employee item)
        {

            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEmployee";
                cmd.Parameters.AddWithValue("@Id", item.Id);
             //   cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Contact", item.Contact);
              //  cmd.Parameters.AddWithValue("@CompanyId", item.CompanyId);
                cmd.Parameters.AddWithValue("@hourrate", item.hourrate);
                
                cmd.Parameters.AddWithValue("@password", item.password);
              //  cmd.Parameters.AddWithValue("@username", item.username);
                cmd.Parameters.AddWithValue("@active", item.active);
                cmd.Parameters.AddWithValue("@Status", item.Status);
                connection.Open();

                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        #endregion
        public static Employee GetFromReader(SqlDataReader dr)
        {
            Employee item = new Employee();

            item.Id = dr.GetInt32(dr.GetOrdinal("Id"));
            if (!dr.IsDBNull(dr.GetOrdinal("password")))
                item.password = dr.GetString(dr.GetOrdinal("password"));
            if (!dr.IsDBNull(dr.GetOrdinal("username")))
                item.username = dr.GetString(dr.GetOrdinal("username"));  
            if (!dr.IsDBNull(dr.GetOrdinal("Name")))
                item.Name = dr.GetString(dr.GetOrdinal("Name"));
            if (!dr.IsDBNull(dr.GetOrdinal("Contact")))
                item.Contact = dr.GetString(dr.GetOrdinal("Contact"));
            if (!dr.IsDBNull(dr.GetOrdinal("CompanyId")))
                item.CompanyId = dr.GetInt32(dr.GetOrdinal("CompanyId"));
            if (!dr.IsDBNull(dr.GetOrdinal("hourrate")))
                item.hourrate = dr.GetString(dr.GetOrdinal("hourrate"));
           
            if (!dr.IsDBNull(dr.GetOrdinal("active")))
                item.active = dr.GetString(dr.GetOrdinal("active"));
            if (!dr.IsDBNull(dr.GetOrdinal("Status")))
                item.Status = dr.GetInt32(dr.GetOrdinal("Status"));
            if (!dr.IsDBNull(dr.GetOrdinal("DateCreated")))
                item.DateCreated = dr.GetDateTime(dr.GetOrdinal("DateCreated"));

            return item;
        }
    }
}
