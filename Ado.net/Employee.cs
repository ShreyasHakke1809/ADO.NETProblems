using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net
{
    internal class Employee
    {
        public static string connectioString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CustomersDetails;Integrated Security=True;";

        public static void GetAllEmployees()
        {
            SqlConnection sqlConnection = new SqlConnection(connectioString);
            try
            {
                sqlConnection.Open();
                string query = "select * from CustomersTable";
                SqlCommand cmd = new SqlCommand(query,sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        int CustomerId = Convert.ToInt32(reader["CustomerId"] == DBNull.Value ? default : reader["CustomerId"]); 
                        string CustomerName = Convert.ToString(reader["CustomerName"] == DBNull.Value ? default : reader["CustomerName"]);
                        long Phone = Convert.ToInt64(reader["Phone"] == DBNull.Value ? default : reader["Phone"]);
                        string Address = Convert.ToString(reader["Address"] == DBNull.Value ? default : reader["Address"]);
                        string Country = Convert.ToString(reader["Country"] == DBNull.Value ? default : reader["Country"]);
                        long Salary = Convert.ToInt64(reader["Salary"] == DBNull.Value ? default : reader["Salary"]);
                        long Pincode = Convert.ToInt64(reader["Pincode"] == DBNull.Value ? default : reader["Pincode"]);

                        Console.WriteLine($"{CustomerId} {CustomerName} {Phone} {Address} {Country} {Salary} {Pincode}");
                    }
                }
                else
                {
                    Console.WriteLine("No data");
                }
                sqlConnection.Close();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void InsertData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectioString);
            try
            {
                sqlConnection.Open();
                CustomerDetails customer = new CustomerDetails();
                Console.WriteLine("Enter Name : ");
                customer.CustomerName = Console.ReadLine();
                Console.WriteLine("Enter Phone Number : ");
                customer.Phone = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Address : ");
                customer.Address = Console.ReadLine();
                Console.WriteLine("Enter Country : ");
                customer.Country = Console.ReadLine();
                Console.WriteLine("Enter Salary : ");
                customer.Salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Pincode : ");
                customer.Pincode = Convert.ToInt32(Console.ReadLine());
                string query = "'"+customer.CustomerName + "'," + customer.Phone + ",'" + customer.Address + "','" + customer.Country + "'," + customer.Salary + "," + customer.Pincode + ")";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                Console.WriteLine("Inserted Data Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void DeleteData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectioString);
            try
            {
                CustomerDetails customer = new CustomerDetails();
                sqlConnection.Open();
                string query = "delete from CustomersTable Where CustomerId=2";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data is Deleted From Table");
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void UpdateData()
        {
            SqlConnection sqlConnection = new SqlConnection(connectioString);
            try
            {
                sqlConnection.Open();
                string query = "update CustomersTable Set Salary = 70000 Where CustomerId=3";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data is Updated");
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
