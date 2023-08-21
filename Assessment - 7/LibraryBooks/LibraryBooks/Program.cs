using System;
using System.Data.SqlClient;
using System.Data;


namespace LibraryBooks
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter adapter;
        static DataSet ds;
        static SqlDataReader reader;
        static string conString = "server=DESKTOP-PE7BHIE;database=LibraryDB;trusted_connection=true;";
        static void Main(string[] args)
        {
            try
            {
                repeat:
                con = new SqlConnection(conString);
                cmd = new SqlCommand();

                Console.WriteLine("\n**Library's Book Inventory**");
                Console.WriteLine(" 1.Retrieve Data\n 2.Display Book Inventory\n 3.Add New Book\n 4.Update Book Quantity\n 5.Exit");
                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            con = new SqlConnection(conString);
                            cmd = new SqlCommand("select * from Books", con);
                            adapter = new SqlDataAdapter(cmd);
                            con.Open();
                            ds = new DataSet();
                            adapter.Fill(ds);
                            con.Close();
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                Console.WriteLine("\nBookId: " + ds.Tables[0].Rows[i]["BookId"]);
                                Console.WriteLine("Title: " + ds.Tables[0].Rows[i]["Title"]);
                                Console.WriteLine("Author: " + ds.Tables[0].Rows[i]["Author"]);
                                Console.WriteLine("Genre: " + ds.Tables[0].Rows[i]["Genre"]);
                                Console.WriteLine("Quantity: " + ds.Tables[0].Rows[i]["Quantity"]);

                            }
                            break;
                        }
                    case 2:
                        {
                            con = new SqlConnection(conString);
                            cmd = new SqlCommand("select * from Books", con);
                            con.Open();
                            reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                Console.WriteLine(reader["BookId"]);
                                Console.WriteLine(reader["Title"]);
                                Console.WriteLine(reader["Author"]);
                                Console.WriteLine(reader["Genre"]);
                                Console.WriteLine(reader["Quantity"]);

                                Console.WriteLine("");
                            }
                            con.Close();
                            break;

                        }
                    case 3:
                        {
                            con = new SqlConnection(conString);
                            cmd = new SqlCommand("select * from Books", con);
                            adapter = new SqlDataAdapter(cmd);
                            con.Open();
                            ds = new DataSet();
                            adapter.Fill(ds, "Books");
                            DataTable dt = ds.Tables["Books"];
                            DataRow dr = dt.NewRow();
                            Console.WriteLine("Enter BookId");
                            dr["BookId"] = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Title");
                            dr["Title"] = Console.ReadLine();
                            Console.WriteLine("Enter Author");
                            dr["Author"] = Console.ReadLine();

                            Console.WriteLine("Enter Genre");
                            dr["Genre"] = Console.ReadLine();
                            Console.WriteLine("Enter Quantity");
                            dr["Quantity"] = int.Parse(Console.ReadLine());
                            dt.Rows.Add(dr);

                            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
                            adapter.Update(ds, "Books");
                            Console.WriteLine("**Added successfully**");

                            break;
                        }
                    case 4:
                        {
                            con = new SqlConnection(conString);
                            cmd = new SqlCommand("select * from Books", con);
                            adapter = new SqlDataAdapter(cmd);
                            con.Open();
                            ds = new DataSet();
                            adapter.Fill(ds);
                            DataTable dt = ds.Tables[0];
                            Console.WriteLine("Enter Book Id to  update Book Quantity");
                            int cid = int.Parse(Console.ReadLine());
                            DataRow dr = null;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if ((int)dt.Rows[i]["BookId"] == cid)
                                {
                                    dr = dt.Rows[i];
                                    break;
                                }
                            }
                            if (dr != null)
                            {
                                Console.WriteLine("Enter New Quantity");
                                dr["Quantity"] = Console.ReadLine();

                                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
                                adapter.Update(ds);
                                Console.WriteLine("**Updated Successfully**");

                            }
                            else
                            {
                                Console.WriteLine("No such Record Exist!!!");
                            }
                            break;
                        }
                    case 5:
                        Console.WriteLine("Exit...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;

                }
                goto repeat;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!" + ex.Message);
            }
            finally
            {
                Console.ReadKey();

            }
        }
    }
}