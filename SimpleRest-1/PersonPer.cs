using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using SimpleRest_1.Models;

namespace SimpleRest_1
{
    public class PersonPer
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-7QEUT3S;Initial Catalog=Rest;Integrated Security=True");
        public PersonPer()
        {
            try
            {
                conn.Open();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public long SavePerson(Person personToSave)
        {

            String sqlString = "INSERT INTO PERSON(FirstName,LastName,PayRate,StartDate,EndDate)    VALUES('" + personToSave.FirstName + "','" + personToSave.LastName + "'," + personToSave.PayRate + ",'" + personToSave.StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "','" + personToSave.EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            SqlCommand cmd = new SqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery();
            decimal id = (decimal)cmd.ExecuteScalar();
            return (long)id;


        }
    }
}
