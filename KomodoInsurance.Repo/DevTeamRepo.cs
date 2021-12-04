using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomodoInsurance.POCO;

namespace KomodoInsurance.Repo
{
    public class DevTeamRepo
    {
        private List<DevTeam> _devTeamRepo = new List<DevTeam>();
        private int _id = 0;

        //crud methods on devTeam.

        //where do we add a developer to a team, reference the teamID on the dev?
        
       

        //Create
        public bool AddDevTeam(DevTeam d)
        {
            if(d == null)
            {
                return false;
            }
            else
            {
                _id++;
                d.Id = _id;
                _devTeamRepo.Add(d);
                return true;
            }
            
        }

        //Read (all)
        public List<DevTeam> GetListOfDevTeams()
        {
            return _devTeamRepo;
        }


        //Read (one)
        public DevTeam GetTeamByID(int id)
        {
            foreach (DevTeam dt in _devTeamRepo)
            {
                if(dt.Id == id)
                {
                    return dt;
                }
               
            }
            return null;
        }

        //Update

        public bool UpdateDevTeam(int id, DevTeam newTeamData)
        {
            foreach(DevTeam dt in _devTeamRepo)
            {
                if (dt.Id == id)
                {
                    dt.TeamName = newTeamData.TeamName;
                    return true;
                }
            }
            return false;
        }


        //Delete
        public bool DeleteDevTeam(int id)
        {
            foreach(DevTeam dt in _devTeamRepo)
            {
                if (dt.Id == id)
                {
                    _devTeamRepo.Remove(dt);
                    return true;
                }
                
            }
            return false;
        }


        //use a helper methods to add and remove developers from a team outside of the other DevTeam CRUd operations.

        public bool AddDeveloperToTeam(Developer developerToAdd, int teamToAddToId)
        {
            foreach(DevTeam dt in _devTeamRepo)
            {
                if (dt.Id == teamToAddToId)
                {
                    dt.TeamMembers.Add(developerToAdd);
                    return true;
                }
            }
            return false;
        }

        public void RemoveDeveloperFromAllTeams(Developer developerToBeRemoved)
        {
            foreach (DevTeam dt in _devTeamRepo)
            {
                foreach (Developer d in dt.TeamMembers.ToList())
                {
                    if (d.Id == developerToBeRemoved.Id)
                    {
                        dt.TeamMembers.Remove(d);
                    }
                }
            }
        }
    }
}
