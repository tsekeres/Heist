using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heist.Team_Members
{
    class CrewMember
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public decimal CourageFactor { get; set; }

        public CrewMember(string name, int skillLevel, decimal courageFactor)
        {
            Name = name;
            SkillLevel = skillLevel;
            CourageFactor = courageFactor;

        }

        public void CrewMemberInfo()
        {
            Console.WriteLine($"Crew Member: {Name}, Skill Level: {SkillLevel}, Courage Factor: {CourageFactor}");
        }

    }
}
