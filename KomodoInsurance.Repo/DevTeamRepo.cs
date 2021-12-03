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
        private int id;

        //crud methods on devTeam.

        //where do we add a developer to a team, reference the teamID on the dev?

        public bool AddDevTeam(DevTeam d)
        {
            return true;
        }
    }
}
