using System;
using System.Text.RegularExpressions;
using Model;
using DataAccessLibrabry;

namespace Validation
{
    public class Validate
    {
        public bool isValidMobileNumber(int inputMobileNumber)
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
    }
}
