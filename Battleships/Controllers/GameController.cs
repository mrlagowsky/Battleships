using Battleships.Enums;
using Battleships.Models;

namespace Battleships.Controllers
{
    public class GameController
    {
        private BattleGrid _grid;

        public GameController()
        {
            _grid = new BattleGrid();
        }

        public BattleGrid Grid { get { return _grid; } set { _grid = value; } }

        public void PlayGame()
        {
            while (!_grid.AllShipsSunk())
            {
                Console.Clear();
                DrawGrid();
                Console.WriteLine("Enter coordinates (e.g., A5): ");
                string input = Console.ReadLine();

                if (input.Length == 3 && char.IsLetter(input[0]) && char.IsDigit(input[1]) && char.IsDigit(input[2]))
                {
                    int col = char.ToUpper(input[0]) - 'A';
                    int row = int.Parse(input.Substring(1)) - 1;

                    EvaluateShot(col, row);
                }
                else if(input.Length == 2 && char.IsLetter(input[0]) && char.IsDigit(input[1]))
                {
                    int col = char.ToUpper(input[0]) - 'A';
                    int row = int.Parse(input[1].ToString()) - 1;

                    EvaluateShot(col, row);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                // In case we have a hit or a miss we'd like the user to have time to find out which one it was
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }

            //Clear and draw the grid once a shot has been taken
            Console.Clear();
            DrawGrid();
            Console.WriteLine("Congratulations, you sunk all the battleships!");
        }

        /// <summary>
        /// This function will check whether the shot that was taken by the user has hit or missed
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        public void EvaluateShot(int col, int row)
        {
            try
            {
                // Check if the coordinates are within the valid range
                if (col >= 0 && col < 10 && row >= 0 && row < 10)
                {
                    GridSquareStatus status = _grid.GetSquareStatus(row, col);

                    if (status == GridSquareStatus.Ship)
                    {
                        Console.WriteLine("Hit!");
                        _grid.UpdateSquareStatus(row, col, GridSquareStatus.Hit);
                    }
                    else if (status == GridSquareStatus.Empty)
                    {
                        Console.WriteLine("Miss!");
                        _grid.UpdateSquareStatus(row, col, GridSquareStatus.Miss);
                    }
                    else if (status == GridSquareStatus.Hit || status == GridSquareStatus.Miss)
                    {
                        Console.WriteLine("You already fired at that square!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid status!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates!");
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                // Handle the exception gracefully
                Console.WriteLine($"Error: {ex.Message}");
            }
        }



        /// <summary>
        /// Method to re-draw and display the grid with results in the console window
        /// </summary>
        public void DrawGrid()
        {
            Console.WriteLine("   A B C D E F G H I J");
            for (int row = 0; row < 10; row++)
            {
                Console.Write((row + 1).ToString().PadLeft(2) + " ");
                for (int col = 0; col < 10; col++)
                {
                    GridSquareStatus status = _grid.GetSquareStatus(row, col);
                    switch (status)
                    {
                        case GridSquareStatus.Empty:
                            Console.Write(". ");
                            break;
                        case GridSquareStatus.Ship:
                            Console.Write(". ");
                            break;
                        case GridSquareStatus.Hit:
                            Console.Write("X ");
                            break;
                        case GridSquareStatus.Miss:
                            Console.Write("O ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
