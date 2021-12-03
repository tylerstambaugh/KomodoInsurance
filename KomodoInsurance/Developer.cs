using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.POCO
{
    public class Developer
    {
        // set up Developer object. Create constructors and properties.

        //"Database of developers, until we learn to write out to actual DB.
        List<Developer> _developerList = new List<Developer>();
        
        public Developer() {}

        public Developer(string fName, string lName, Title title, decimal salary, DateTime hireDate, bool hasPluralsightAccess)
        {
            FirstName = fName;
            LastName = lName;
            Title = title;
            Salary = salary;
            HireDate = hireDate;
            HasPluralsightAccess = hasPluralsightAccess;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Title Title{ get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public bool HasPluralsightAccess { get; set; }

        

    }
}
