using System;
using System.Data.SqlClient;
using System.Data;

namespace ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"data source=LAPTOP-HE1NGVBC\SQLEXPRESS;database=student;integrated security=SSPI");
            try
            {
                String sql = "SELECT * from studentDetails";
                SqlCommand cmd = new SqlCommand(sql,connection);
                connection.Open();
                //SqlDataReader rdr = cmd.ExecuteReader();
                //rdr.Close();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * from studentDetails", connection);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.Write(row[column]+"\t");
                    }
                    Console.WriteLine();
                }
                // creating stored procedure//
                //string query = @"CREATE PROCEDURE SampleStoredProcedure
                //  (
                //  @Rollno int,
                //  @Name VARCHAR(50),@age int

                //  )
                //AS
                //  INSERT INTO studentDetails(Rollno,Name,Age) Values(@Rollno,@Name,@Age)";

                //cmd = new SqlCommand(query, connection);


                //cmd.ExecuteNonQuery();
                //Console.WriteLine("Store Procedure Created Successfully");

                //cmd = new SqlCommand("SampleStoredProcedure", connection);

                //--------Inserting values-----//
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@Rollno", 20));
                //cmd.Parameters.Add(new SqlParameter("@Name", "Ajith"));
                //cmd.Parameters.Add(new SqlParameter("@Age", 20));
                //int i = cmd.ExecuteNonQuery();
                //if (i > 0)
                //{
                //    Console.WriteLine("Records Inserted Successfully.");
                //}
                //string query = @"CREATE PROCEDURE RetrieveDataProcedure
                //(
                //    @Name VARCHAR(50)
                //    )
                //    AS
                //        SELECT* FROM studentdetails where Name = @Name";
                //cmd = new SqlCommand(query, connection);
                //cmd.ExecuteNonQuery();
                cmd = new SqlCommand("RetrieveDataProcedure", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", "dinesh"));
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("student roll no : " + dr[0].ToString());
                    Console.WriteLine("student name : " + dr[1].ToString());
                    Console.WriteLine("student age : " + dr[2].ToString());
                }
                //while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetInt32(0));

                //}
           

            }
            catch (Exception ex)
            {
                Console.WriteLine("OOPS!something went wrong"+ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
