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

        public DevTeam(string teamName, string teamManager)
        {
            TeamName = teamName;
            TeamManager = teamManager;
        }

        public int Id { get; set; }

        public string TeamName { get; set; }

        public string TeamManager { get; set; }
    }
}
