using Battleships.Enums;

namespace Battleships.Models
{
    public class BattleGrid
    {
        private GridSquareStatus[,] squares;

        /// <summary>
        /// In the default constructor we initialize a 10x10 grid for the game and place the ships randomly on that grid
        /// </summary>
        public BattleGrid()
        {
            squares = new GridSquareStatus[10, 10];
            InitializeGrid();
            PlaceShips();
        }

        /// <summary>
        /// This method will initialize a new blank 10x10 grid with [Empty] statuses
        /// </summary>
        public void InitializeGrid()
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    squares[row, col] = GridSquareStatus.Empty;
                }
            }
        }

        /// <summary>
        /// Default implementation of PlaceShips that according to specification places 3 ships of size 
        /// </summary>
        private void PlaceShips()
        {
            PlaceShip(5);
            PlaceShip(4);
            PlaceShip(4);
        }

        /// <summary>
        /// This method will position the ships of given size on the grid using a random assignment 
        /// The logic is split between horizontal and vertical placement due to a different indexer being used to identify the grid position
        /// </summary>
        /// <param name="size">Specify the size of the ship</param>
        public void PlaceShip(int size)
        {
            Random random = new Random();
            bool placed = false;

            while (!placed)
            {
                // First we find a random available position for a ship
                int row = random.Next(10);
                int col = random.Next(10);
                bool isHorizontal = random.Next(2) == 0;

                if (isHorizontal && col + size <= 10)
                {
                    bool available = true;
                    for (int c = col; c < col + size; c++)
                    {
                        if (squares[row, c] != GridSquareStatus.Empty)
                        {
                            // If this position is not available we want to find a different one so we break out of the loop
                            available = false;
                            break;
                        }
                    }

                    if (available)
                    {
                        for (int c = col; c < col + size; c++)
                        {
                            // When we find a suitable position on the grid we mark it as unavailable by assigning a status there
                            squares[row, c] = GridSquareStatus.Ship;
                        }
                        placed = true;
                    }
                }
                else if (!isHorizontal && row + size <= 10)
                {
                    // We execute the same logic as above but for a non-horizontal placement
                    bool available = true;
                    for (int r = row; r < row + size; r++)
                    {
                        if (squares[r, col] != GridSquareStatus.Empty)
                        {
                            available = false;
                            break;
                        }
                    }

                    if (available)
                    {
                        for (int r = row; r < row + size; r++)
                        {
                            squares[r, col] = GridSquareStatus.Ship;
                        }
                        placed = true;
                    }
                }
            }
        }

        /// <summary>
        /// This method is for checking the status of a particular grid position given it's row and column
        /// </summary>
        /// <param name="row">Specify the row of the grid position</param>
        /// <param name="col">Specify the column of the grid position</param>
        /// <returns>The status of a given grid position in an active game</returns>
        public GridSquareStatus GetSquareStatus(int row, int col)
        {
            return squares[row, col];
        }

        /// <summary>
        /// This method will update the specified grid position with a new status when the player makes a move
        /// </summary>
        /// <param name="row">Specify the row of the grid position</param>
        /// <param name="col">Specify the column of the grid position</param>
        /// <param name="status">Specify the desired status for this grid element</param>
        public void UpdateSquareStatus(int row, int col, GridSquareStatus status)
        {
            squares[row, col] = status;
        }

        /// <summary>
        /// This method will scan through the grid and check whether the whole board has been cleared of battle ships - meaning the user has won
        /// </summary>
        public bool AllShipsSunk()
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (squares[row, col] == GridSquareStatus.Ship)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
