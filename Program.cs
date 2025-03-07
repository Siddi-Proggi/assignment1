using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace assignment_1
{
    public class Program
    {
        // variables for TicTacToe
        private static int status = 0; //0: game in progress, 1: win, 2: draw
        private static string[] symbols = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };

        private static string player1 = "X";
        private static string player2 = "O";
        
        static void Main(string[] args)
        {


            int gameChoice = 0;

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("                      Welcome to the gaming Zone");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine();
            Console.WriteLine("Enter choice");
            Console.WriteLine("1. Play Tic Tac Toe (with your Buddy)");
            Console.WriteLine("2. Play Rock, Paper, Scissors  (with Computer)");
            Console.WriteLine("3. Exit");

            do
            {
                gameChoice = Convert.ToInt32(Console.ReadLine());

                if (gameChoice == 1)
                {
                    Console.WriteLine("Tic Tac Toe");
                    GameBoard();
                    Console.WriteLine();
                    PlayTicTacToe();

                }
                else if (gameChoice == 2)
                {
                    Console.WriteLine("Rock, Paper, Scissors");
                    PlayRockPaperScissors();
                }
                else if (gameChoice == 3)
                {
                    Console.WriteLine("Bye Bye");
                }
                else if (gameChoice > 3)
                {
                    Console.WriteLine("This is not an option");
                }

                Console.ReadLine();
            } while (gameChoice != 3);

          

        }

        private static void PlayRockPaperScissors()
        {
            int choice = 0;
            int computerChoice = 0;


            Console.WriteLine("Enter your choice (e.g. 1 for Rock, 2 for Paper, 3 for Scissors)");
            choice = Convert.ToInt32(Console.ReadLine());

            // how to generate a random number 
            Random random = new Random();
            computerChoice = random.Next(1, 4);

            Console.WriteLine("You chose: " + choice);
            Console.WriteLine("The Computer chose: " + computerChoice);

            // Check for win or lose
            if (choice == 1 && computerChoice == 2)
            {
                Console.WriteLine("You Lose :(");
            }
            else if (choice == 2 && computerChoice == 3)
            {
                Console.WriteLine("You Lose :(");
            }
            else if (choice == 3 && computerChoice == 1)
            {
                Console.WriteLine("You Lose :(");
            }
            else if (choice == 3 && computerChoice == 2)
            {
                Console.WriteLine("You Win :)");
            }
            else if (choice == 1 && computerChoice == 3)
            {
                Console.WriteLine(" You Win :)");
            }
            else if (choice == computerChoice)
            {
                Console.WriteLine("Draw!");
            }
        }

        private static void PlayTicTacToe()
        {
            bool isPlayer1 = true;
            int position = 0;


            // this loop would continue unless one player wins or the game is a tie
            do
            {
                if (isPlayer1 == true)
                {
                    Console.WriteLine("Player 1 Enter Position value");

                    if (int.TryParse(Console.ReadLine(), out position))
                    {
                        if (symbols[position] == "X" || symbols[position] == "O")
                        {
                            Console.WriteLine("This position is already taken, please select another");
                        }
                        else
                        {
                            symbols[position] = player1;
                            GameBoard();
                            status = CheckWinOrDraw();
                            if (status == 1)
                            {
                                Console.WriteLine("\nPlayer 1 wins");
                            }
                            else if (status == 2)
                            {
                                Console.WriteLine("Draw");
                            }
                            isPlayer1 = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid integer");
                    }

                }
                else if (isPlayer1 == false)
                {
                    Console.WriteLine("Player 2 Enter Position value");
                    if (int.TryParse(Console.ReadLine(), out position))
                    {
                        if (symbols[position] == "X" || symbols[position] == "O")
                        {
                            Console.WriteLine("This position is already taken, please select another");
                        }
                        else
                        {
                            symbols[position] = player2;
                            GameBoard();
                            status = CheckWinOrDraw();
                            if (status == 1)
                            {
                                Console.WriteLine("\nPlayer 2 wins");
                            }
                            else if (status == 2)
                            {
                                Console.WriteLine("Draw");
                            }
                            isPlayer1 = true;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid integer");
                    }

                }
            } while (status == 0);


        }
        // Draw game board
        private static void GameBoard()
        {
            Console.Clear();
            Console.WriteLine("Player 1: X     Player 2: O");
            Console.WriteLine();
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |   {2}  ", symbols[0], symbols[1], symbols[2]);
            Console.WriteLine("-----|-----| -----");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |   {2}  ", symbols[3], symbols[4], symbols[5]);
            Console.WriteLine("-----|-----| -----");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |   {2}  ", symbols[6], symbols[7], symbols[8]);
        }

        // function to check a win or draw
        private static int CheckWinOrDraw()
        {
            int result = 0;
            // horizontal combination
            if (symbols[0] == symbols[1] && symbols[1] == symbols[2])
            {
                result = 1;
            }
            else if (symbols[3] == symbols[4] && symbols[4] == symbols[5])
            {
                result = 1;
            }
            else if (symbols[6] == symbols[7] && symbols[7] == symbols[8])
            {
                result = 1;
            }
            // vertical combination
            else if (symbols[0] == symbols[3] && symbols[3] == symbols[6])
            {
                result = 1;
            }
            else if (symbols[1] == symbols[4] && symbols[4] == symbols[7])
            {
                result = 1;
            }
            else if (symbols[2] == symbols[5] && symbols[5] == symbols[8])
            {
                result = 1;
            }
            // diagonal
            else if (symbols[0] == symbols[4] && symbols[4] == symbols[8])
            {
                result = 1;
            }
            else if (symbols[2] == symbols[4] && symbols[4] == symbols[6])
            {
                result = 1;
            }
            // check for draw
            else if (symbols[0] != "0" && symbols[1] != "1" && symbols[2] != "2" && symbols[3] != "2" && symbols[4] != "3"
                    && symbols[5] != "5" && symbols[6] != "6" && symbols[7] != "7" && symbols[8] != "8")
            {
                result = 2;
            }

            return result;
        }
    }
}
