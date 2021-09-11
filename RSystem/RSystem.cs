using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLibrabry;
using Model;

namespace RSystem
{
    class RSystem
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================================================================================================================================================================================");
            Console.WriteLine("*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*Welcome To RSystem*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*|*");
            Console.WriteLine("==================================================================================================================================================================================================================");

            DAL dAL = new DAL();

            dAL.DisplayActiveRestarant();


            char Option = '\0';

            do
            {
                Repeate:
                Console.WriteLine("Select Specific Option from following");
                Console.WriteLine("Search Restaurant in Rsystem                 : S");
                Console.WriteLine("Display Restaurant from RSystem              : D");
                Console.WriteLine("Add new Restaurant to List                   : A");
                Console.WriteLine("Delete Exising Restaurant from Rsystem       : L");
                Console.WriteLine("Update Restaurant details from Rsystem       : U");
                Console.WriteLine("Activate/Deactivate Restaurant from Rsystem  : X");
                Console.WriteLine();
                Console.Write("Give Input: ");

                char select = Convert.ToChar(Console.ReadLine());
                switch (select)
                {
                    case 'S':
                        {
                            dAL.SearchRestaurant();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Do You Want To Continue Press 'Y' :");
                            Option = Convert.ToChar(Console.ReadLine());
                            break;
                        }
                    case 'D':
                        {
                            dAL.DisplayAllRestarant();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Do You Want To Continue Press 'Y' :");
                            Option = Convert.ToChar(Console.ReadLine());
                            break;
                        }
                    case 'A':
                        {
                            Restaurant rest = dAL.GetRestaurant();
                            dAL.AddRestaurnat(rest);
                            dAL.DisplayAllRestarant();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Do You Want To Continue Press 'Y' :");
                            Option = Convert.ToChar(Console.ReadLine());
                            break;
                        }
                    case 'L':
                        {

                            dAL.DeleteRestaurant();
                            dAL.DisplayAllRestarant();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Do You Want To Continue Press 'Y' :");
                            Option = Convert.ToChar(Console.ReadLine());
                            break;
                        }
                    case 'U':
                        {
                            Restaurant rest1 = dAL.GetRestaurant();
                            dAL.UpdateRestaurant(rest1);
                            dAL.DisplayAllRestarant();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Do You Want To Continue Press 'Y' :");
                            Option = Convert.ToChar(Console.ReadLine());
                            break;
                        }
                    case 'X':
                        {
                            Restaurant rest2 = dAL.GetInputRestaurant();
                            dAL.ActivateDeactivateRestaurant(rest2);
                            dAL.DisplayAllRestarant();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Do You Want To Continue Press 'Y' :");
                            Option = Convert.ToChar(Console.ReadLine());
                            break;
                        }
                    default:
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Select Correct Option");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            goto Repeate;
                            
                        }
                }
            }while (Option == 'Y');

            Console.WriteLine();

            Console.WriteLine("=================================================================================================================================================================================================================");
            Console.WriteLine("!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!  Thank You for Using RSystem  !_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!_!");
            Console.WriteLine("=================================================================================================================================================================================================================");

        }
    }
}
