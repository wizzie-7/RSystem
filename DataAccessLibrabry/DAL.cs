using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Model;
//using Validation;


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
                Console.WriteLine("==================================================================================================================================================================================================================");
                Console.WriteLine("*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*Active Restaurants*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*");
                Console.WriteLine("==================================================================================================================================================================================================================");
                foreach (DataRow row in DT.Rows)
                {
                    Console.WriteLine(" \t| " + row["RestName"].ToString() + " |\t| " + row["RestAdreess"].ToString() + " |\t| " + row["RestPhoneNo"].ToString() + " |\t| " + row["RestCuisine"].ToString() + " |\t ");
                    Console.WriteLine();
                }
                Console.WriteLine("==================================================================================================================================================================================================================="+Environment.NewLine);
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
                Console.WriteLine("===================================================================================================================================================================================================================");
                Console.WriteLine("*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*List of Restaurants*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*");
                Console.WriteLine("===================================================================================================================================================================================================================");
                foreach (DataRow row in DT.Rows)
                {
                    Console.WriteLine(" \t| " + row["RestId"].ToString() + " |\t| " + row["RestName"].ToString() + " |\t| " + row["RestAdreess"].ToString() + " |\t| " + row["RestPhoneNo"].ToString() + " |\t| " + row["RestOpeningTime"].ToString() + " |\t| " + row["RestClosingTime"].ToString() + " |\t| " + row["RestCuisine"].ToString() + " |     | " + row["RestStatus"].ToString() + " |\t ");
                    Console.WriteLine();
                }
                Console.WriteLine("====================================================================================================================================================================================================================" + Environment.NewLine);
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
        public void SearchRestaurant()
        {
            string RestName = string.Empty;

            Console.Write("Search Restaurant: ");
            RestName = Console.ReadLine();

            DataTable DT = ExecuteData("select RestName, RestAdreess, RestPhoneNo, RestOpeningTime, RestClosingTime, RestCuisine from Restaurant where RestName='"+RestName+"'");
            if (DT.Rows.Count > 0)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("===================================================================================================================================================================================================================");
                Console.WriteLine("*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*Searched Restaurant*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*");
                Console.WriteLine("===================================================================================================================================================================================================================");
                foreach (DataRow row in DT.Rows)
                {
                    Console.WriteLine(row["RestName"].ToString() + "\t|\t" + row["RestAdreess"].ToString() + "\t|\t" + row["RestPhoneNo"].ToString() + "\t|\t" + row["RestCuisine"].ToString());
                    Console.WriteLine();
                }
                Console.WriteLine("===================================================================================================================================================================================================================" + Environment.NewLine);
            }
            else
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine("!!!"+RestName+" not found!!!");
                Console.Write(Environment.NewLine);
            }
        }
        public Restaurant GetRestaurant()
        {
            int RestId = 0;
            string RestName = string.Empty;
            string RestAdress = string.Empty;
            long RestPhoneNo;
            string RestOpeningTime = string.Empty;
            string RestClosingTime = string.Empty;
            string RestCuisine = string.Empty;
            string RestStatus = string.Empty;

            //Validate V = new Validate();

            Console.Write("Enter Restaurant ID(Restaurant ID must me number only): ");
            RestId = Convert.ToInt32(Console.ReadLine());
            
            while (true)
            {
                Console.Write("Enter Restaurant Name(Do not use special character in Restaurant Name.): ");
                RestName = Console.ReadLine();

                if (Regex.IsMatch(RestName, "^[a-zA-Z0-9 ]*$"))
                {
                        break;
                }
                else
                {
                        Console.WriteLine("Enter Restaurant Without Special Characters...");
                        continue;
                }
            }
            
            Console.Write("Enter Adress of Restaurant: ");
            RestAdress = Console.ReadLine();
            while (string.IsNullOrEmpty(RestAdress))
            {
                Console.WriteLine("Please ent Adress of Restaurant... ");
                Console.WriteLine();
                Console.Write("Enter Adress of Restaurant: ");
                RestAdress = Console.ReadLine();
            }
            while (true)
            {
                Console.Write("Enter Phone number of Restaurant: ");
                RestPhoneNo = Convert.ToInt64(Console.ReadLine());
                bool check = isValidMobileNumber(RestPhoneNo);


                if (check == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Length of Phone number must be 10!!!");
                    continue;
                }

            }
            while (true)
                {
                    Console.Write("Enter opening time of Restaurant as per 24 Hr Clock(HH:MM): ");
                    RestOpeningTime = Console.ReadLine();
                    bool status = isValidTime(RestOpeningTime);
                    if (status == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter Opening Time as per the 24 Hrs clock...");
                        continue;
                    }
                }
            
            while (string.IsNullOrEmpty(RestClosingTime))
            {
                while (true)
                {
                    Console.Write("Enter closing time of Restaurant as per 24 Hr Clock(HH:MM): ");
                    RestClosingTime = Console.ReadLine();
                    bool status = isValidTime(RestClosingTime);
                    if (status == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter Opening Time as per the 24 Hrs clock...");
                        continue;
                    }
                }
            }
            while (string.IsNullOrEmpty(RestCuisine))
            {
                while (true)
                {
                    Console.Write("Enter Cuisine of Restaurant: ");
                    RestCuisine = Console.ReadLine();
                    bool status = isValidInput(RestCuisine);
                    if (status == true)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Cuisine Must be from'Indian,Italian,Maxican,Chinese,American'...");
                        continue;
                    }

                }
            }
            
                //Console.WriteLine("Please Eneter Status of Restaurant!!!");
                //Console.WriteLine();
                Console.Write("Enter Activity of Restaurant Active/Deactive: ");
                RestStatus = Console.ReadLine();
             
            Restaurant restaurant = new Restaurant()
            {
                RestId = RestId,
                RestName = RestName,
                RestAdress = RestAdress,
                RestPhoneNo = RestPhoneNo,
                RestOpeningTime = RestOpeningTime,
                RestClosingTime = RestClosingTime,
                RestCuisine = RestCuisine,
                RestStatus = RestStatus,
            };
            return restaurant;
        }
        public bool isValidMobileNumber(long inputMobileNumber)
        {
            string strRegex = @"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9] {2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)";


            Regex re = new Regex(strRegex);


            if (re.IsMatch(Convert.ToString(inputMobileNumber)))
            {
                return (true);
            }

            else
            {
                return (false);
            }

        }
        public bool isValidInput(string str)
        {
            string strRegex = "Indian";
            string strRegex2 = "Italian";
            string strRegex3 = "Chinese";
            string strRegex4 = "Maxican";
            string strRegex5 = "American";

            Regex re = new Regex(strRegex);
            Regex re1 = new Regex(strRegex2);
            Regex re2 = new Regex(strRegex3);
            Regex re3 = new Regex(strRegex4);
            Regex re4 = new Regex(strRegex5);
            if (re.IsMatch(str) || re1.IsMatch(str) || re2.IsMatch(str) || re3.IsMatch(str) || re4.IsMatch(str))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public bool isValidTime(string str)
        {
            string strRegex = "^[0-2][0-3]:[0-5][0-9]$";
            Regex re = new Regex(strRegex);


            if (re.IsMatch(str))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public void AddRestaurnat(Restaurant restaurant)
        {
            ExecuteCommand(String.Format("Insert into Restaurant(RestId,RestName,RestAdreess,RestPhoneNo,RestOpeningTime,RestClosingTime,RestCuisine,RestStatus) values ({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}')", restaurant.RestId, restaurant.RestName, restaurant.RestAdress, restaurant.RestPhoneNo, restaurant.RestOpeningTime, restaurant.RestClosingTime, restaurant.RestCuisine, restaurant.RestStatus));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Restaurant has been added in your list.");
        }
        public void UpdateRestaurant(Restaurant restaurant)
        {
            ExecuteCommand(String.Format("Update Restaurant set RestId={0}, RestName='{1}', " + "RestAdreess='{2}', RestPhoneNo={3}, RestOpeningTime='{4}', RestClosingTime='{5}', " + "RestCuisine='{6}', RestStatus='{7}' where RestId={0}", restaurant.RestId, restaurant.RestName, restaurant.RestAdress, restaurant.RestPhoneNo, restaurant.RestOpeningTime, restaurant.RestClosingTime, restaurant.RestCuisine, restaurant.RestStatus));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Restaurant has been update in your list.");
        }
        public Restaurant GetInputRestaurant()
        {
            int RestId=0;
            string RestStatus = string.Empty;

            //Console.WriteLine("Add New Restaurant: ");

            Console.Write("Enter Restaurant Id: ");
            RestId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Activity of Restaurant Active/Deactive: ");
            RestStatus = Console.ReadLine();

            Restaurant restaurant = new Restaurant()
            {
                RestId = RestId,
                RestStatus = RestStatus,
            };
            return restaurant;
        }
        public void ActivateDeactivateRestaurant(Restaurant restaurant)
        {
            ExecuteCommand(String.Format("Update Restaurant set RestStatus='{1}' where RestId={0}", restaurant.RestId,restaurant.RestStatus));
        }
        public bool ExecuteCommand(string queury)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(constr))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(queury, sqlcon);
                    cmd.ExecuteNonQuery();
                    sqlcon.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
                throw;
            }
            return true;
        }
        public void DeleteRestaurant()
        {
            int RestId=0;

            Console.WriteLine("Delet Existing Restarant: ");

            Console.Write("Enter Id of Restaurant: ");
            RestId = Convert.ToInt32(Console.ReadLine());

            ExecuteCommand(String.Format("Delete from Restaurant where RestId = '{0}'", RestId));

            Console.WriteLine("Restaurant SuccessFully Deleted from RSystem!!!!" + Environment.NewLine);
        }

    }
}
