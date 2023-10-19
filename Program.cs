using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeBattle
{
    class Program
    {
        //Creating the battlefield
        static char[,] battleField =
            {
                {'1','2','3'},  //Row 0
                {'4','5','6'},  //Row 1
                {'7','8','9'}   //Row 2
            };

        //Battle turns
        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2; // Player 1 starts
            int input = 0;
            bool inputCorrect = true;

            //run code as long as the program runs
            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXorO(player, input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO(player, input);
                }

                SetBattleField();

                #region Check Winning Condition
                //Check Winning Condition   
                char[] playerChars = { 'X', 'O' };

                foreach (char playerChar in playerChars)
                {
                    if (((battleField[0, 0] == playerChar) && (battleField[0, 1] == playerChar) && (battleField[0, 2] == playerChar))
                         || ((battleField[1, 0] == playerChar) && (battleField[1, 1] == playerChar) && (battleField[1, 2] == playerChar))
                         || ((battleField[2, 0] == playerChar) && (battleField[2, 1] == playerChar) && (battleField[2, 2] == playerChar))
                         || ((battleField[0, 0] == playerChar) && (battleField[1, 0] == playerChar) && (battleField[2, 0] == playerChar))
                         || ((battleField[0, 1] == playerChar) && (battleField[1, 1] == playerChar) && (battleField[2, 1] == playerChar))
                         || ((battleField[0, 2] == playerChar) && (battleField[1, 2] == playerChar) && (battleField[2, 2] == playerChar))
                         || ((battleField[0, 0] == playerChar) && (battleField[1, 1] == playerChar) && (battleField[2, 2] == playerChar))
                         || ((battleField[0, 2] == playerChar) && (battleField[1, 1] == playerChar) && (battleField[2, 0] == playerChar))
                         )
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("\nPlayer 2 has won!");
                        }
                        else
                        {
                            Console.WriteLine("\nPlayer 1 has won!");
                        }

                        Console.WriteLine("Press any Key to Reset the Game");
                        Console.ReadKey();
                        ResetBattleField();
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("Draw");
                        Console.WriteLine("Press any Key to Reset the Game");
                        Console.ReadKey();
                        ResetBattleField();
                        break;
                    }
                }
                #endregion


                #region
                //Test if field is already taken
                do
                {
                    Console.Write("\nPlayer {0}: Choose your field! ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Plese enter a number!");
                    }

                    if ((input == 1) && (battleField[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (battleField[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (battleField[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (battleField[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (battleField[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (battleField[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (battleField[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (battleField[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (battleField[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\n Field already taken! Please use another field!");
                        inputCorrect = false;
                    }

                } while (!inputCorrect);
                #endregion

            } while (true);
        }

        public static void ResetBattleField()
        {
            char[,] battleFieldInitial =
            {
                {'1','2','3'},
                {'4','5','6'},
                {'7','8','9'}
            };

            battleField = battleFieldInitial;
            SetBattleField();
            turns = 0;
        }

        public static void SetBattleField()
        {
            Console.Clear();
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", battleField[0, 0], battleField[0, 1], battleField[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", battleField[1, 0], battleField[1, 1], battleField[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", battleField[2, 0], battleField[2, 1], battleField[2, 2]);
            Console.WriteLine("     |     |     ");
            turns++;
        }

        public static void EnterXorO(int player, int input)
        {
            char playerSign = ' ';

            if (player == 1)
                playerSign = 'X';
            else if (player == 2)
                playerSign = 'O';

            switch (input)
            {
                case 1: battleField[0, 0] = playerSign; break;
                case 2: battleField[0, 1] = playerSign; break;
                case 3: battleField[0, 2] = playerSign; break;
                case 4: battleField[1, 0] = playerSign; break;
                case 5: battleField[1, 1] = playerSign; break;
                case 6: battleField[1, 2] = playerSign; break;
                case 7: battleField[2, 0] = playerSign; break;
                case 8: battleField[2, 1] = playerSign; break;
                case 9: battleField[2, 2] = playerSign; break;
            }
        }
    }
}
