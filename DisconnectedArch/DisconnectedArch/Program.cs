//using System;
//using System.Data.SqlClient;
//using System.Data;

//namespace DisconnectedArch
//{
//    internal class Program
//    {
//        static SqlConnection con;
//        static SqlCommand cmd;  
//        static SqlDataAdapter adapter;
//        static DataSet ds;
//        static string conString = "server=DESKTOP-PE7BHIE;database=Day7Db; trusted_connection = true;";

//        static void Main(string[] args)
//        {
//            try
//            {
//                con = new SqlConnection(conString);
//                cmd = new SqlCommand("select * from Customer",con);
//                adapter = new SqlDataAdapter(cmd);
//                con.Open();
//                ds = new DataSet();
//                adapter.Fill(ds);
//                con.Close();

//                for(int i=0; i < ds.Tables[0].Rows.Count; i++)
//                {
//                    Console.WriteLine("ID: " + ds.Tables[0].Rows[i]["Id"]);
//                    Console.WriteLine("Name: " + ds.Tables[0].Rows[i]["Name"]);
//                    Console.WriteLine("ODLimit: " + ds.Tables[0].Rows[i]["ODLimit"]);
//                    Console.WriteLine("StartDate: " + ds.Tables[0].Rows[i]["SStartDate"]);
//                    Console.WriteLine("EndDate: " + ds.Tables[0].Rows[i]["SEndDate"]);

//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error!!" + ex.Message);
//            }
//            finally 
//            {
//               

//            }
//        }
//    }
//}


//DataReader
//using System;
//using System.Data.SqlClient;

//namespace DisconnectedArch
//{
//    internal class Program
//    {
//        static SqlConnection con;
//        static SqlCommand cmd;
//        static SqlDataReader reader;

//        static string conString = "server=DESKTOP-PE7BHIE;database=Day7Db; trusted_connection = true;";

//        static void Main(string[] args)
//        {
//            try
//            {
//                con = new SqlConnection(conString);
//                cmd = new SqlCommand("select * from Customer", con);
//                 con.Open();
//                reader = cmd.ExecuteReader();

//                Console.WriteLine("ID \t Name\t ODLimit\t SStartDAte\t\t EndDAte");
//                while (reader.Read())
//                {
//                    Console.Write(reader["ID"] + "\t");
//                    Console.Write(reader["Name"] + "\t");
//                    Console.Write(reader["ODLimit"] + "\t\t");
//                    Console.Write(reader["SStartDate"] + "\t ");
//                    Console.Write(reader["SEndDate"] + "\t");
//                    Console.WriteLine("\n");
//                }
//            }

//            catch (Exception ex)
//            {
//                Console.WriteLine("Error!!" + ex.Message);
//            }
//            finally
//            {
//                con.Close();    
//                Console.WriteLine("End of Program!!");
//                Console.ReadKey();
//            }
//        }
//    }
//}



//using System;
//using System.Data.SqlClient;


//namespace DisconnectedArch
//{
//    internal class Program
//    {
//        static SqlConnection con;
//        static SqlCommand cmd;
//        static string conString = "server= DESKTOP-PE7BHIE;database=Day7Db; trusted_connection = true;";
//        static void Main(string[] args)
//        {
//            try
//            {
//                con = new SqlConnection(conString);
//                con.Open();
//                cmd = new SqlCommand();
//                cmd.CommandText = "insert into Customer " + "(Id,Name,ODLimit,SStartDate ,SEndDate) values(@id,@name,@odlimit, @sd ,@ed)";
//                cmd.Connection = con;
//                Console.WriteLine("enter Id");
//                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
//                Console.WriteLine("Enter Name");
//                cmd.Parameters.AddWithValue("@Name", Console.ReadLine());
//                Console.WriteLine("Enter ODLimit");
//                cmd.Parameters.AddWithValue("ODLimit", double.Parse(Console.ReadLine()));
//                Console.WriteLine("Enter StartDate");
//                cmd.Parameters.AddWithValue("@sd", DateTime.Parse(Console.ReadLine()));
//                Console.WriteLine("Enter EndDate");
//                cmd.Parameters.AddWithValue("@ed", DateTime.Parse(Console.ReadLine()));
//                cmd.ExecuteNonQuery();
//                Console.WriteLine("Added!!!");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error!!!" + ex.Message);
//            }
//            finally
//            {
//                Console.WriteLine("End of Program!!!");
//                Console.ReadKey();
//            }
//        }
//    }
//}


//insert

//using System;
//using System.Data;
//using System.Data.SqlClient;


//namespace DisconnectedArch
//{
//    internal class Program
//    {
//        static SqlConnection con;
//        static SqlCommand cmd;
//        static SqlDataAdapter adapter;
//        static DataSet ds;
//        static string conString = "server= DESKTOP-PE7BHIE;database=Day7Db; trusted_connection = true;";
//        static void Main(string[] args)
//        {
//            try
//            {
//                con = new SqlConnection(conString);
//                cmd = new SqlCommand("select * from Customer", con);
//                adapter = new SqlDataAdapter(cmd);
//                con.Open();
//                ds = new DataSet();
//                adapter.Fill(ds, "Customer");  
//                DataTable dt = ds.Tables["Customer"]; 
//                DataRow dr = dt.NewRow();

//                Console.WriteLine("enter Id");
//                dr["Id"] = int.Parse(Console.ReadLine());
//                Console.WriteLine("Enter Name");
//                dr["Name"] =Console.ReadLine();
//                Console.WriteLine("Enter ODLimit");
//                dr["ODLimit"]= double.Parse(Console.ReadLine());
//                Console.WriteLine("Enter StartDate");
//                dr["SStartDate"] = DateTime.Parse(Console.ReadLine());
//                Console.WriteLine("Enter EndDate");
//                dr["SEndDate"] = DateTime.Parse(Console.ReadLine());
//                dt.Rows.Add(dr);
//                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
//                adapter.Update(ds, "Customer");
//                Console.WriteLine("Inserted!!!");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error!!!" + ex.Message);
//            }
//            finally
//            {
//                con.Close();
//                Console.WriteLine("End of Program!!!");
//                Console.ReadKey();
//            }
//        }
//    }
//}


//using System;
//using System.Data;
//using System.Data.SqlClient;


//namespace DisconnectedArch
//{
//    internal class Program
//    {
//        static SqlConnection con;
//        static SqlCommand cmd;
//        static SqlDataAdapter adapter;
//        static DataSet ds;
//        static string conString = "server= DESKTOP-PE7BHIE;database=Day7Db; trusted_connection = true;";
//        static void Main(string[] args)
//        {
//            try
//            {
//                con = new SqlConnection(conString);
//                cmd = new SqlCommand("select * from Customer", con);
//                adapter = new SqlDataAdapter(cmd);
//                con.Open();
//                ds = new DataSet();
//                adapter.Fill(ds);
//                DataTable dt = ds.Tables[0];
//                DataRow dr = dt.NewRow();

//                Console.WriteLine("enter Id");
//                dr["Id"] = int.Parse(Console.ReadLine());
//                Console.WriteLine("Enter Name");
//                dr["Name"] = Console.ReadLine();
//                Console.WriteLine("Enter ODLimit");
//                dr["ODLimit"] = double.Parse(Console.ReadLine());
//                Console.WriteLine("Enter StartDate");
//                dr["SStartDate"] = DateTime.Parse(Console.ReadLine());
//                Console.WriteLine("Enter EndDate");
//                dr["SEndDate"] = DateTime.Parse(Console.ReadLine());
//                dt.Rows.Add(dr);
//                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
//                adapter.Update(ds);
//                Console.WriteLine("Added!!!");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error!!!" + ex.Message);
//            }
//            finally
//            {
//                con.Close();
//                Console.WriteLine("End of Program!!!");
//                Console.ReadKey();
//            }
//        }
//    }
//}


//delete
//using System;
//using System.Data;
//using System.Data.SqlClient;


//namespace DisconnectedArch
//{
//    internal class Program
//    {
//        static SqlConnection con;
//        static SqlCommand cmd;
//        static SqlDataAdapter adapter;
//        static DataSet ds;
//        static string conString = "server= DESKTOP-PE7BHIE;database=Day7Db; trusted_connection = true;";
//        static void Main(string[] args)
//        {
//            try
//            {
//                con = new SqlConnection(conString);
//                cmd = new SqlCommand("select * from Customer", con);
//                adapter = new SqlDataAdapter(cmd);
//                con.Open();
//                ds = new DataSet();
//                adapter.Fill(ds);
//                DataTable dt = ds.Tables[0];
//                Console.WriteLine("Enter Customer Id to delete Customer");
//                int cid = int.Parse(Console.ReadLine());

//                DataRow dr = dt.NewRow();
//                for(int i=0; i<dt.Rows.Count; i++)
//                {
//                    if((int)dt.Rows[i]["Id"]==cid)
//                    {
//                        dr = dt.Rows[i];
//                        break;
//                    }
//                }
//                if(dr!=null)
//                {
//                    dr.Delete();
//                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
//                    adapter.Update(ds);
//                    Console.WriteLine("Record Deleted!!");

//                }
//                else
//                {
//                    Console.WriteLine("No such record exist!!");
//                }
               
                
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error!!!" + ex.Message);
//            }
//            finally
//            {
           
//                Console.WriteLine("End of Program!!!");
//                Console.ReadKey();
//            }
//        }
//    }
//}


//update
using System;
using System.Data;
using System.Data.SqlClient;


namespace DisconnectedArch
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter adapter;
        static DataSet ds;
        static string conString = "server= DESKTOP-PE7BHIE;database=Day7Db; trusted_connection = true;";
        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conString);
                cmd = new SqlCommand("select * from Customer", con);
                adapter = new SqlDataAdapter(cmd);
                con.Open();
                ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                Console.WriteLine("Enter Customer Id to update Customer");
                int cid = int.Parse(Console.ReadLine());

                DataRow dr = dt.NewRow();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((int)dt.Rows[i]["Id"] == cid)
                    {
                        dr = dt.Rows[i];
                        break;
                    }
                }
                if (dr != null)
                {
                    Console.WriteLine("Enter Name");
                    dr["Name"] = Console.ReadLine();
                    Console.WriteLine("Enter ODLimit");
                    dr["ODLimit"] = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter StartDate");
                    dr["SStartDate"] = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter EndDate");
                    dr["SEndDate"] = DateTime.Parse(Console.ReadLine());
                    
                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
                    adapter.Update(ds);
                    Console.WriteLine("Record Updates!!");

                }
                else
                {
                    Console.WriteLine("No such record exist!!");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!" + ex.Message);
            }
            finally
            {

                Console.WriteLine("End of Program!!!");
                Console.ReadKey();
            }
        }
    }
}










