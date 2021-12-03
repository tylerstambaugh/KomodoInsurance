using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance.POCO
{
    public class DevTeam
    {
        List<DevTeam> _devTeamList = new List<DevTeam>();

        public DevTeam() { }

        public DevTeam(string teamName)
        {
            TeamName = teamName;
            TeamMembers = new List<Developer>();

        }

        public int Id { get; set; }

        public string TeamName { get; set; }

        public string TeamManager { get; set; }
        public List<Developer> TeamMembers { get; set; }
    }
}
