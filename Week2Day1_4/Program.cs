// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Week2Day1_4.Managers;

// namespace IPLBiddingApp
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // Create instances of managers
//             TeamManager teamManager = new TeamManager();
//             PlayerManager playerManager = new PlayerManager();

//             while (true)
//             {
//                 Console.WriteLine("\nIPL Bidding Console App Menu:");
//                 Console.WriteLine("1. List Players");
//                 Console.WriteLine("2. Find Player");
//                 Console.WriteLine("3. Add Player");
//                 Console.WriteLine("4. Edit Player");
//                 Console.WriteLine("5. Delete Player");
//                 Console.WriteLine("6. Exit");
//                 Console.Write("Enter your choice: ");

//                 if (int.TryParse(Console.ReadLine(), out int choice))
//                 {
//                     switch (choice)
//                     {
//                         case 1:
//                             playerManager.ListPlayers();
//                             playerManager.ListPlayers1();
//                             playerManager.DisplayAllPlayers();
//                             break;
//                         case 2:
//                             Console.Write("Enter player name to find: ");
//                             string playerName = Console.ReadLine();
//                             playerManager.FindPlayer(playerName);
//                             break;
//                         case 3:
//                             playerManager.AddPlayer();
//                             break;
//                         case 4:
//                             playerManager.EditPlayer();
//                             break;
//                         case 5:
//                             playerManager.DeletePlayer();
//                             break;
//                         case 6:
//                             Environment.Exit(0);
//                             break;
//                         default:
//                             Console.WriteLine("Invalid choice. Please try again.");
//                             break;
//                     }
//                 }
//                 else
//                 {
//                     Console.WriteLine("Invalid input. Please enter a number.");
//                 }
//             }
//         }
//     }
// }
