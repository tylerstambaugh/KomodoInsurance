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
        private readonly DevTeamRepo _devTeamRepo = new DevTeamRepo();
        public void Run()
        {
            SeedData();
            RunApplication();
        }

        public void MainMenu()
        {
            // just a method to easily write the menu to the console. Nothing else.

            Console.WriteLine("This is going to be the menu \n" +
                "1. Create a Developer \n" +
                "2. Get Developer by ID \n" +
                "3. Developer Directory \n" +
                "4. Update A Developer by ID\n" +
                "5. Remove a Developer by ID\n" +
                "6. Add Dev Team \n" +
                "7. Display Dev Teams \n" +
                "8. Display Dev Team w/ Team Members\n" +
                "9. Unassign Developer From Team\n" +
                "10. Assign Developer To Team \n" +
                "99. Exit with Style");

        }
        private void RunApplication()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                MainMenu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateDeveloper();
                        break;
                    case "2":
                        GetDeveloperByID();
                        break;
                    case "3":
                        GetListOfAllDevelopers();
                        break;
                    case "4":
                        UpdateDeveloperById();
                        break;
                    case "5":
                        DeleteDeveloperById();
                        break;
                    case "6":
                        CreateDevTeam();
                        break;
                    case "7":
                       DisplayDevTeams();
                        break;
                    case "8":
                        DisplayDevTeamsWithTeamMembers();
                        break;
                    case "9":
                        RemoveDeveloperFromTeam();
                        break;
                    case "10":
                        AddDeveloperToTeam();
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

        // Call the CRUD methods in the repos, passing the appropriate arguments.
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
            Console.Clear();
            List<Developer> listOfDevelopers = _developerRepo.GetListOfDevelopers();
            foreach (Developer d in listOfDevelopers)
            {
                Console.WriteLine($"ID: {d.Id} \n" +
                $"First Name: {d.FirstName} \n" +
                $"Last Name: {d.LastName } \n" +
                $"Title: {d.Title} \n" +
                $"Salary: {d.Salary} \n" +
                $"Hire Date: {d.HireDate} \n" +
                $"Has Pluralsight Access: {d.HasPluralsightAccess } \n" +
                $"***************************");
                
            }
            Console.WriteLine("Press and key to return.");
            Console.ReadLine();
        }

        private void UpdateDeveloperById()
        {
            Console.Clear();

            Console.WriteLine("Please enter the ID of the developer to update:");
            int devToUpdateID = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the developer's updated first name:");
            string devFirstName = Console.ReadLine();

            Console.WriteLine("Please enter the developer's updated last name:");
            string devLastName = Console.ReadLine();

            Console.WriteLine("Please enter the # of the developer's updated title:\n" +
                "1. Junior Developer \n" +
                "2. Associate Developer \n" +
                "3. Intern \n" +
                "4. Senior Developer \n" +
                "5. Quality Analyst");
            int titleSelection = Int32.Parse(Console.ReadLine());
            Title title = (Title)titleSelection;

            Console.WriteLine("Please enter the developer's updated  salary: xxxxx.xx");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Please enter the developer's updated hire month: mm");
            int hireMonth = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the developer's updated hire day: dd");
            int hireDay = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the developer's updated hire year: yyyy");
            int hireYear = Int32.Parse(Console.ReadLine());
            DateTime hireDate = new DateTime(hireYear, hireMonth, hireDay);

            Console.WriteLine("Please enter y/n if the developer has Pluralsight access:");
            bool hasPluralSightAccess = false;

            Console.ReadLine();

            Developer updatedDev = new Developer(devFirstName, devLastName, title, salary, hireDate, hasPluralSightAccess);

            bool devUpdatedSuccessfully = _developerRepo.UpdateDeveloper(devToUpdateID, updatedDev);

            if(devUpdatedSuccessfully)
            {
                Console.WriteLine("Success. Press any key to return.");
            }
            else
            {
                Console.WriteLine("something happened, but it wasn't what you thought it would be.");
            }
            Console.ReadLine();

        }

        private void DeleteDeveloperById()
        {

        }

        private void CreateDevTeam()
        {
            Console.WriteLine("Please Enter the team name:");
            string teamName = Console.ReadLine();
            DevTeam teamToBeAdded = new DevTeam(teamName);
            bool addedTeamSuccessfully = _devTeamRepo.AddDevTeam(teamToBeAdded);
            if (addedTeamSuccessfully)
            {
                Console.WriteLine("Team Added Successfully");
            }
            else 
            {
                Console.WriteLine("Something went wrong. Trying again will likely not work. Such is life.");
            }


        }

        private void DisplayDevTeams()
        {
            Console.Clear();
            List<DevTeam> listOfTeams = _devTeamRepo.GetListOfDevTeams();
            foreach(DevTeam dt in listOfTeams)
            {
                Console.WriteLine($"Team ID: {dt.Id}\t Team Name: {dt.TeamName}");
            }
            Console.WriteLine("Press any key to return.");
            Console.ReadLine();
        }

        private void DisplayDevTeamsWithTeamMembers()
        {
            List<DevTeam> listOfTeams = _devTeamRepo.GetListOfDevTeams();
            
            foreach(DevTeam dt in listOfTeams)
            {
                List<Developer> teamMembers = dt.TeamMembers;
                Console.WriteLine($"Team {dt.TeamName}:\n" +
                    $"**************************");
                if (teamMembers != null)
                {
                    foreach (Developer d in teamMembers)
                    {
                        Console.WriteLine($"ID: {d.Id}\t Name: {d.FirstName} {d.LastName} \t Position: {d.Title}");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to return");
            Console.ReadLine();
        }

        private void AddDeveloperToTeam()
        {
            Console.Clear();
            Console.WriteLine("Please enter the ID of the team member you would like to assign:");
            int teamMemberId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the team ID you would like to assign them to.");
            int teamId = Int32.Parse(Console.ReadLine());
            Developer devToAdd = _developerRepo.GetDeveloperByID(teamMemberId);
            //first remvoe them from existing team:

            _devTeamRepo.RemoveDeveloperFromAllTeams(devToAdd);

            bool addedToTeam = _devTeamRepo.AddDeveloperToTeam(devToAdd, teamId);
            if (addedToTeam == true)
            {
                Console.WriteLine("Team member added successfully. Press any key to continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Something went wrong. Please wait until further notice.");
                Console.ReadLine();
            }
        }

        private void RemoveDeveloperFromTeam()
        {
            Console.Clear();
            Console.WriteLine("Please enter the ID of the team member you would like to unassign:");
            int teamMemberId = Int32.Parse(Console.ReadLine());
            Developer devToUnassign = _developerRepo.GetDeveloperByID(teamMemberId);
            _devTeamRepo.RemoveDeveloperFromAllTeams(devToUnassign);
            Console.WriteLine("Thank you. Press any key to return.");
            Console.ReadLine();
        }
        private void SeedData()
        {
            Developer dev1 = new Developer("Tyler", "Bobe", (Title)1, 85000.00m, new DateTime(2021, 11, 01), false);
            Developer dev2 = new Developer("Rob", "Roy", (Title)2, 85000.00m, new DateTime(2019, 09, 08), false);
            Developer dev3 = new Developer("Dwayne", "Marquis", (Title)3, 85000.00m, new DateTime(2021, 01, 01), false);
            _developerRepo.AddDeveloper(dev1);
            _developerRepo.AddDeveloper(dev2);
            _developerRepo.AddDeveloper(dev3);

            DevTeam team1 = new DevTeam("Lasercats");
            DevTeam team2 = new DevTeam("Pop Tarts");
            DevTeam team3 = new DevTeam("Wolfpack");

            _devTeamRepo.AddDevTeam(team1);
            _devTeamRepo.AddDevTeam(team2);
            _devTeamRepo.AddDevTeam(team3);
            _devTeamRepo.AddDeveloperToTeam(dev1, 1);
            _devTeamRepo.AddDeveloperToTeam(dev2, 2);
            _devTeamRepo.AddDeveloperToTeam(dev3, 1);
        }

    }
}
