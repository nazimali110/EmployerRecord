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
    public class Attendances
    {
        #region Get


        public static Attendance GetById(int id)
        {
            Attendance item = new Attendance();
            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand command = new SqlCommand("SelectAttendanceById", connection);//SelectRegisterInterestById needed to create
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

        public static List<Attendance> GetByEmpId(int empId)
        {
            List<Attendance> items = new List<Attendance>();
            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand command = new SqlCommand("SelectAttendanceByEmpId", connection);//SelectRegisterInterestById needed to create
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmpId", empId);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {

                    items = new List<Attendance>();
                    while (reader.Read())
                    {
                        Attendance item = GetFromReader(reader);
                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public static List<Attendance> GetAll()
        {
            List<Attendance> items = null;
            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand command = new SqlCommand("SelectAttendance", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    items = new List<Attendance>();
                    while (reader.Read())
                    {
                        Attendance item = GetFromReader(reader);
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
        public static Int32 Add(Attendance item)
        {

            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertAttendance";
                cmd.Parameters.AddWithValue("@TimeIn", item.TimeIn);
              //  cmd.Parameters.AddWithValue("@TimeOut", item.TimeOut);
                cmd.Parameters.AddWithValue("@EmployeeId", item.EmployeeId);
                cmd.Parameters.AddWithValue("@Date", item.Date);
                cmd.Parameters.AddWithValue("@Type", item.Type);
                cmd.Parameters.AddWithValue("@lat", item.lat);
                cmd.Parameters.AddWithValue("@lon", item.lon);
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
        public static Int32 Update(Attendance item)
        {

            using (SqlConnection connection = Common.Helper.Connection)
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateAttendance";
             //   cmd.Parameters.AddWithValue("@Id", item.Id);
             //   cmd.Parameters.AddWithValue("@TimeIn", item.TimeIn);
                cmd.Parameters.AddWithValue("@TimeOut", item.TimeOut);
                cmd.Parameters.AddWithValue("@EmployeeId", item.EmployeeId);
                cmd.Parameters.AddWithValue("@Date", item.Date);
                cmd.Parameters.AddWithValue("@Type", item.Type);
            //    cmd.Parameters.AddWithValue("@Status", item.Status);
                cmd.Parameters.AddWithValue("@lat", item.lat);
                cmd.Parameters.AddWithValue("@lon", item.lon);
                connection.Open();

                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        #endregion
        public static Attendance GetFromReader(SqlDataReader dr)
        {
            Attendance item = new Attendance();

            item.Id = dr.GetInt32(dr.GetOrdinal("Id"));

            if (!dr.IsDBNull(dr.GetOrdinal("TimeIn")))
                item.TimeIn = dr.GetString(dr.GetOrdinal("TimeIn"));
            // if (!dr.IsDBNull(dr.GetOrdinal("email")))
            //     item.email = dr.GetString(dr.GetOrdinal("email"));
            if (!dr.IsDBNull(dr.GetOrdinal("TimeOut")))
                item.TimeOut = dr.GetString(dr.GetOrdinal("TimeOut"));
            if (!dr.IsDBNull(dr.GetOrdinal("EmployeeId")))
                item.EmployeeId = dr.GetInt32(dr.GetOrdinal("EmployeeId"));
            if (!dr.IsDBNull(dr.GetOrdinal("Date")))
                item.Date = dr.GetString(dr.GetOrdinal("Date"));
            if (!dr.IsDBNull(dr.GetOrdinal("Type")))
                item.Type = dr.GetString(dr.GetOrdinal("Type"));
            if (!dr.IsDBNull(dr.GetOrdinal("Status")))
                item.Status = dr.GetInt32(dr.GetOrdinal("Status"));
            if (!dr.IsDBNull(dr.GetOrdinal("DateCreated")))
                item.DateCreated = dr.GetDateTime(dr.GetOrdinal("DateCreated"));
            if (!dr.IsDBNull(dr.GetOrdinal("lat")))
                item.lat = dr.GetString(dr.GetOrdinal("lat"));
            if (!dr.IsDBNull(dr.GetOrdinal("lon")))
                item.lon = dr.GetString(dr.GetOrdinal("lon"));

            return item;
        }
    }
}
