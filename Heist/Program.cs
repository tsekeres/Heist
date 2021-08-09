using Heist.Team_Members;
using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CrewMember> crew = new List<CrewMember>();
            
            Console.WriteLine("Plan Your Heist!");

            Console.WriteLine("First pick a bank difficulty level from 50(easy) to 100(difficult).");
            var enteredBankDifficultyLevel = Console.ReadLine();
            var bankDifficultyLevel = Convert.ToInt32(enteredBankDifficultyLevel);

            Console.WriteLine("Enter a crew member's name:");
            var name = Console.ReadLine();

            Console.WriteLine($"Enter a Skill Level for {name}. Should be a positive whole number between 1 - 40.");
            var skillLevel = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter {name}'s Courage Factor. Should be a decimal between 0.0 to 2.0.");
            var courageFactor = decimal.Parse(Console.ReadLine());

            var newMember = new CrewMember(name, skillLevel, courageFactor);

            crew.Add(newMember);

            Console.WriteLine($"Your crew has {crew.Count} members.");

            while (name != "")
            {
                Console.WriteLine("Enter another crew member's name. Or hit enter to stop adding crew members.");
                name = Console.ReadLine();

                if (name != "")
                {
                    Console.WriteLine($"Enter a Skill Level for {name}. Should still be a positive whole number between 1 - 40.");
                    skillLevel = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Enter {name}'s Courage Factor. Should be a decimal between 0.0 to 2.0.");
                    courageFactor = decimal.Parse(Console.ReadLine());
            
                    newMember = new CrewMember(name, skillLevel, courageFactor);

                    crew.Add(newMember);

                    Console.WriteLine($"Your crew has {crew.Count} members.");

                } else
                {
                    break;
                }


            }

            var crewSkillLevel = 0;

            foreach (var member in crew)
            {
                crewSkillLevel += member.SkillLevel;
            }

            Console.WriteLine($"Your crew has {crew.Count} members with a skill level total of {crewSkillLevel}");
            Console.WriteLine("------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the number of trial runs you want to see for your heist plan (from 1 to 10):");
            var enteredTrialRuns = Console.ReadLine();
            var trialRuns = Convert.ToInt32(enteredTrialRuns);
            Console.WriteLine($"Your crew will attempt {trialRuns} trial runs.");

            var rnd = new Random();
            var successfulRuns = 0;
            var failedRuns = 0;

            for (var i = 0; i < trialRuns; i++)
            {
                var difficultyLevel = bankDifficultyLevel;
                var luckValue = rnd.Next(-10, 10);
                difficultyLevel += luckValue;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"This bank has a difficulty level of {difficultyLevel}.");

                if ( difficultyLevel <= crewSkillLevel)
                {
                    Console.WriteLine("Yee Haw! Ya'll done got away with it! Heist successful.");
                    successfulRuns++;
                } else
                {
                    Console.WriteLine("Ya'll are goin away for a long time. Heist failed.");
                    failedRuns++;
                }

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Your crew of {crew.Count} ran through {trialRuns} attempts.");
            Console.WriteLine($"With a crew skill level of {crewSkillLevel} you had {successfulRuns} successful attempts.");
            Console.WriteLine($"Your crew had {failedRuns} failed attempts.");

            if (successfulRuns < failedRuns)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I wouldn't try this bank.");
            } else if (successfulRuns == failedRuns)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This is touch and go. Go with your gut on this one.");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Go for it. Your crew has got this licked.");
            }
        }
    }
}


