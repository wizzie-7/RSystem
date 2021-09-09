using System;
using System.Data;
using System.Data.SqlClient;
using Model;


namespace DataAccessLibrabry
{  
    public class DAL
    {
        static string constr = "data source=DESKTOP-912JH4M\\SQLEXPRESS;initial catalog=RSystem;integrated security=True;";

        public void DisplayActiveRestarant()
        {
            DataTable DT = ExecuteData("select * from Restaurant where RestStatus='Active'");
            if (DT.Rows.Count > 0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("======================================================================");
                Console.WriteLine("**************************Active Restaurants**************************");
                Console.WriteLine("======================================================================");
                foreach (DataRow row in DT.Rows)
                {
                    Console.WriteLine(row["RestName"].ToString() + " " + row["RestAdreess"].ToString() + " " + row["RestPhoneNo"].ToString() + " " + row["RestCuisine"].ToString());
                }
                Console.WriteLine("======================================================================" + Environment.NewLine);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("!!!There Is NO Active Restarant!!!");
                Console.Write(Environment.NewLine);
            }
        }
        public void DisplayAllRestarant()
        {
            DataTable DT = ExecuteData("select * from Restaurant");
            if (DT.Rows.Count > 0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("=====================================================================");
                Console.WriteLine("*************************List of Restaurants*************************");
                Console.WriteLine("=====================================================================");
                foreach (DataRow row in DT.Rows)
                {
                    Console.WriteLine(row["RestId"].ToString() + " " + row["RestName"].ToString() + " " + row["RestAdreess"].ToString() + " " + row["RestPhoneNo"].ToString() + " " + row["RestOpeningTime"].ToString() + " " + row["RestClosingTime"].ToString() + " " + row["RestCuisine"].ToString() + " " + row["RestStatus"].ToString());
                }
                Console.WriteLine("======================================================================" + Environment.NewLine);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("!!!No Records Found!!!");
                Console.Write(Environment.NewLine);
            }
        }
        public DataTable ExecuteData(string Query)
        {
            DataTable result = new DataTable();

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(Query, sqlcon);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(result);
                    sqlcon.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
        //public void SearchRestaurant(Restaurant rest)
        //{
        //    string RestName = string.Empty;

        //    Console.Write("Search Restaurant: ");
        //    RestName = Console.ReadLine();

        //    DataTable DT = ExecuteCommand("select {0},{1},{2},{3},{4},{5} from Restaurant where RestName='{0}'", rest.RestName, rest.RestAdress, rest.RestPhoneNo, rest.RestOpeningTime, rest.RestClosingTime, rest.RestCuisine);
        //    if (DT.Rows.Count > 0)
        //    {
        //        Console.Write(Environment.NewLine);
        //        Console.WriteLine("======================================================================");
        //        Console.WriteLine("*************************Searched Restaurants*************************");
        //        Console.WriteLine("======================================================================");
        //        foreach (DataRow row in DT.Rows)
        //        {
        //            Console.WriteLine(row["RestName"].ToString() + " " + row["RestAdreess"].ToString() + " " + row["RestPhoneNo"].ToString() + " " + row["RestCuisine"].ToString());
        //        }
        //        Console.WriteLine("======================================================================" + Environment.NewLine);
        //    }
        //    else
        //    {
        //        Console.Write(Environment.NewLine);
        //        Console.WriteLine("!!!There Is NO Active Restarant!!!");
        //        Console.Write(Environment.NewLine);
        //    }
        //}
        //public Restaurant GetRestaurant()
        //{
        //    string RestId = string.Empty;
        //    string RestName = string.Empty;
        //    string RestAdress = string.Empty;
        //    string RestPhoneNo = string.Empty;
        //    string RestOpeningTime = string.Empty;
        //    string RestClosingTime = string.Empty;
        //    string RestCuisine = string.Empty;
        //    string RestStatus = string.Empty;

        //    Console.WriteLine("Add New Restaurant: ");

        //    Console.Write("Enter Restaurant Id: ");
        //    RestId = Console.ReadLine();

        //    Console.Write("Enter Restaurant Name: ");
        //    RestName = Console.ReadLine();

        //    Console.Write("Enter Adress of Restaurant: ");
        //    RestAdress = Console.ReadLine();

        //    Console.Write("Enter contact of Restaurant: ");
        //    RestPhoneNo = Console.ReadLine();

        //    Console.Write("Enter opening time of Restaurant as per 24 Hr Clock(HH:MM:SS): ");
        //    RestOpeningTime = Console.ReadLine();

        //    Console.Write("Enter closing time of Restaurant as per 24 Hr Clock(HH:MM:SS): ");
        //    RestClosingTime = Console.ReadLine();

        //    Console.Write("Enter Cuisine of Restaurant: ");
        //    RestCuisine = Console.ReadLine();

        //    Console.Write("Enter Activity of Restaurant Active/Deactive: ");
        //    RestStatus = Console.ReadLine();

        //    Restaurant restaurant = new Restaurant()
        //    {
        //        RestId = RestId,
        //        RestName = RestName,
        //        RestAdress = RestAdress,
        //        RestPhoneNo = RestPhoneNo,
        //        RestOpeningTime = RestOpeningTime,
        //        RestClosingTime = RestClosingTime,
        //        RestCuisine = RestCuisine,
        //        RestStatus = RestStatus,
        //    };
        //    return restaurant;
        //}
        //public void AddRestaurnat(Restaurant restaurant)
        //{
        //    ExecuteCommand(String.Format("Insert into Restaurant(RestId,RestName,RestPhoneNo,RestAdreess,RestOpeningTime,RestClosingTime,RestCuisine,RestStatus) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", restaurant.RestId, restaurant.RestName, restaurant.RestAdress, restaurant.RestPhoneNo, restaurant.RestOpeningTime, restaurant.RestClosingTime, restaurant.RestCuisine, restaurant.RestStatus));
        //}
        //public void UpdateRestaurant(Restaurant restaurant)
        //{
        //    ExecuteCommand(String.Format("Update Restaurant set RestId='{0}', RestName='{1}', RestAdress='{2}', RestPhoneNo='{3}', RestOpeningTime='{4}', RestClosingTime='{5}', RestCuisine='{6}', RestStatus='{7}' wher RestId={0}", restaurant.RestId, restaurant.RestName, restaurant.RestAdress, restaurant.RestPhoneNo, restaurant.RestOpeningTime, restaurant.RestClosingTime, restaurant.RestCuisine, restaurant.RestStatus));
        //}
        //public void DeleteRestaurant()
        //{
        //    string RestId = string.Empty;

        //    Console.WriteLine("Delet Existing EMPLOYEE: ");

        //    Console.Write("Enter Empno: ");
        //    RestId = Console.ReadLine();

        //    ExecuteCommand(String.Format("Delete from emp where eno = '{0}'", RestId));

        //    Console.WriteLine("Employee details deleted from the database!" + Environment.NewLine);
        //}
        //public bool ExecuteCommand(string queury)
        //{
        //    try
        //    {
        //        using (SqlConnection sqlcon = new SqlConnection(constr))
        //        {
        //            sqlcon.Open();
        //            SqlCommand cmd = new SqlCommand(queury, sqlcon);
        //            cmd.ExecuteNonQuery();
        //            sqlcon.Close();

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return false;
        //        throw;
        //    }
        //    return true;
        //}
    }
}
