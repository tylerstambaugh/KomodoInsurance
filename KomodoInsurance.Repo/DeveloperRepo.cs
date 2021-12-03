using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoInsurance.POCO;

namespace KomodoInsurance.Repo
{
    public class DeveloperRepo
    {
        //local in memory storage of developer objects to be CRUD'd.
        private readonly List<Developer> _devList = new List<Developer>();
        private int _count = 0;
        //CRUD methods for the Developer object;


        //Create / Add devveloper to in memory list.
        public bool AddDeveloper(Developer d)
        {
            if (d == null)
            {
                return false;
            }
            else
            {
                _count++;
                d.Id = _count;
                _devList.Add(d);
                return true;
            }
        }

        //return the Developer object for a given Id.
        public Developer GetDeveloperByID(int id)
        {
            foreach (Developer d in _devList)
            {
                if (d.Id == id)
                {
                    return d;
                }
            }
            return null;
        }

        //return the entire list of developer objects in memory.
        public List<Developer> GetListOfDevelopers()
        {
            return _devList;
        }

        //remove developer
        public bool RemoveDeveloper(int id)
        {
            foreach (Developer d in _devList)
            {
                if (d.Id == id)
                {
                    _devList.Remove(d);
                    return true;
                }
            }
            return false;
        }

        // update developer
        public bool UpdateDeveloper(int id, Developer updatedDeveloperData)
        {
            Developer oldDeveleoperData = GetDeveloperByID(id);
            if (oldDeveleoperData != null)
            {
                oldDeveleoperData.FirstName = updatedDeveloperData.FirstName;
                oldDeveleoperData.LastName = updatedDeveloperData.LastName;
                oldDeveleoperData.Title = updatedDeveloperData.Title;
                oldDeveleoperData.Salary = updatedDeveloperData.Salary;
                oldDeveleoperData.HireDate = updatedDeveloperData.HireDate;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
