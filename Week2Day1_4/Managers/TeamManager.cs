using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2Day1_4.Models;

namespace Week2Day1_4.Managers
{
    public class TeamManager
    {
        private List<Team> teams = new List<Team>();

        public void CreateTeam()
        {
            Console.Write("Enter Team ID: ");
            int teamId = int.Parse(Console.ReadLine());

            Console.Write("Enter Team Name: ");
            string teamName = Console.ReadLine();

            Console.Write("Enter Maximum Budget: ");
            decimal maxBudget = decimal.Parse(Console.ReadLine());

            Team newTeam = new Team
            {
                Id = teamId,
                Name = teamName,
                MaximumBudget = maxBudget
            };

            teams.Add(newTeam);
            Console.WriteLine("Team created successfully!");
        }

        public void UpdateTeam()
        {
            Console.Write("Enter Team ID to update: ");
            int teamId = int.Parse(Console.ReadLine());

            Team teamToUpdate = teams.FirstOrDefault(t => t.Id == teamId);

            if (teamToUpdate != null)
            {
                Console.Write("Enter new Team Name (leave empty to keep current): ");
                string newTeamName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newTeamName))
                {
                    teamToUpdate.Name = newTeamName;
                }

                Console.Write("Enter new Maximum Budget (leave empty to keep current): ");
                string newBudgetInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newBudgetInput) && decimal.TryParse(newBudgetInput, out decimal newBudget))
                {
                    teamToUpdate.MaximumBudget = newBudget;
                }

                Console.WriteLine("Team information updated successfully!");
            }
            else
            {
                Console.WriteLine($"Team with ID {teamId} not found.");
            }
        }

        public void DeleteTeam()
        {
            Console.Write("Enter Team ID to delete: ");
            int teamId = int.Parse(Console.ReadLine());

            Team teamToDelete = teams.FirstOrDefault(t => t.Id == teamId);

            if (teamToDelete != null)
            {
                teams.Remove(teamToDelete);
                Console.WriteLine("Team deleted successfully!");
            }
            else
            {
                Console.WriteLine($"Team with ID {teamId} not found.");
            }
        }

        public void ListTeams()
        {
            Console.WriteLine("\nList of Teams:");
            foreach (var team in teams)
            {
                Console.WriteLine($"Team ID: {team.Id}, Name: {team.Name}, Maximum Budget: {team.MaximumBudget:C}");
            }
        }
    }
}
