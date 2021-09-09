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
            Console.WriteLine("======================================================================");
            Console.WriteLine("**************************Welcome To RSystem**************************");
            Console.WriteLine("======================================================================");

            Restaurant rest = new Restaurant();

            DAL dAL = new DAL();

            dAL.DisplayActiveRestarant();
            dAL.DisplayAllRestarant();
        }
    }
}
