using KomodoInsurance.POCO;
using KomodoInsurance.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuraceUI
{

    public class ProgramUI
    {

        private readonly DeveloperRepo _developerRepo = new DeveloperRepo();
        public void Run()
        {
            RunApplication();
        }

        public void Menu()
        {
            // just a method to easily write the menu to the console. Nothing else.

            Console.WriteLine("This is going to be the menu \n" +
                "1. Create a Developer \n" +
                "2. Get Developer by ID \n" +
                "3. Get List of All Developers \n" +
                "4. Update A Developer \n" +
                "5. Remove a Developer \n" +
                "6. Team Operations \n" +
                "99. Exit with Style" +
                "");

        }
        private void RunApplication()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Menu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateDeveloper();
                        break;
                    case "2":
                        GetDeveloperByID();
                        break;

                    case "10":
                        break;
                    case "99":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("I'm a computer, you're a banana.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // Call the CRUD methods in the repo, passing the appropriate arguments.
        private void CreateDeveloper()
        { 
            Console.Clear();
            
            Console.WriteLine("Please enter the developer's first name:");
            string devFirstName = Console.ReadLine();
            
            Console.WriteLine("Please enter the developer's last name:");
            string devLastName = Console.ReadLine();
            
            Console.WriteLine("Please enter the # of the developer's title:\n" +
                "1. Junior Developer \n" +
                "2. Associate Developer \n" +
                "3. Intern \n" +
                "4. Senior Developer \n" +
                "5. Quality Analyst");
            int titleSelection = Int32.Parse(Console.ReadLine());
            Title title = (Title)titleSelection;

            Console.WriteLine("Please enter the developer's salary: xxxxx.xx");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
           
            Console.WriteLine("Please enter the developer's hire month: mm");
            int hireMonth = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the developer's hire day: dd");
            int hireDay = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the developer's hire year: yyyy");
            int hireYear = Int32.Parse(Console.ReadLine());
            DateTime hireDate = new DateTime(hireYear, hireMonth, hireDay);
           
            Console.WriteLine("Please enter y/n if the developer has Pluralsight access:");
            bool hasPluralSightAccess = false;
            
            Console.ReadLine();

            Developer devToBeAdded = new Developer(devFirstName, devLastName, title, salary, hireDate, hasPluralSightAccess);

            bool addedDevSuccessfully = _developerRepo.AddDeveloper(devToBeAdded);
            if(addedDevSuccessfully)
            {
                Console.WriteLine($"Developer {devFirstName} {devLastName} was added successfully. Press any key to continue.");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Oh snap!! Check the logs, something went wrong. (did we implement logging?");
                Console.ReadKey();
            }
        }

        private void GetDeveloperByID()
        {
            Console.Clear();
            Console.WriteLine("Please enter the ID of the Developer you would like to view:");
            int getDevId = Int32.Parse(Console.ReadLine());

            Developer dev = _developerRepo.GetDeveloperByID(getDevId);

            Console.WriteLine($"First Name: {dev.FirstName} \n" +
                $"Last Name: {dev.LastName } \n" +
                $"Title: {dev.Title} \n" +
                $"Salary: {dev.Salary} \n" +
                $"Hire Date: {dev.HireDate} \n" +
                $"Has Pluralsight Access: {dev.HasPluralsightAccess } \n" +
                $"***************************");
            Console.WriteLine("Press and key to return.");
            Console.ReadKey();
        }

        private void GetListOfAllDevelopers()
        {

        }

        private void UpdateDeveloperById()
        {

        }

        private void DeleteDeveloperById()
        {

        }

    }
}
