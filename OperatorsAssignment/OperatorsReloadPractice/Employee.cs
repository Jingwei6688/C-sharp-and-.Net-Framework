using System;
using System.Collections.Generic;
using System.Text;

namespace OperatorsReloadPractice
{
    internal class Employee
    {
        public string eName { get; set; }
        public int eID { get; set; }

        //reload the == operator to compare two Employee objects based on their eID
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            return emp1.eID == emp2.eID;
        }

        //reload the != operator to compare two Employee objects based on their eID
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return emp1.eID != emp2.eID;
        }
    }
}
