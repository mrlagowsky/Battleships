<h1>Battleships Game Documentation</h1>

The Battleships game is a console-based implementation of the classic game Battleships, where the player tries to sink all the enemy ships on a 10x10 grid.

<h2>Important Classes</h2>

<h3>GameController</h3>

The GameController class represents the main game controller responsible for managing the game flow. It provides methods for playing the game and evaluating shots taken by the player.

<b>Properties</b>

Grid: Gets or sets the battle grid associated with the game.

<b>Methods:</b>

PlayGame(): Initiates the game loop, allowing the player to take shots and updates the grid accordingly until all ships are sunk.
EvaluateShot(int col, int row): Evaluates the shot taken by the player at the specified coordinates and updates the grid accordingly.
DrawGrid(): Redraws and displays the grid with the current status in the console window.

<h3>BattleGrid</h3>

The BattleGrid class represents the battle grid on which the game is played. It manages the positions of ships and provides methods for initializing the grid, placing ships, and checking the status of grid positions.

<b>Methods:</b>

InitializeGrid(): Initializes a new blank 10x10 grid with all positions set to GridSquareStatus.Empty.
PlaceShips(): Places the ships randomly on the grid according to the default specifications.
PlaceShip(int size): Places a ship of the specified size randomly on the grid, ensuring no overlap with existing ships.
GetSquareStatus(int row, int col): Retrieves the status of the specified grid position.
UpdateSquareStatus(int row, int col, GridSquareStatus status): Updates the status of the specified grid position with the given status.
AllShipsSunk(): Checks whether all ships on the grid have been sunk.

<h2>Enums</h2>

<h3>ShipType</h3>

The ShipType enum represents the types of ships in the game. It includes the following values:

Unknown: Indicates an unknown ship type.
Battleship: Represents a battleship with a size of 4.
Destroyer: Represents a destroyer with a size of 5.

<h3>GridSquareStatus</h3>

The GridSquareStatus enum represents the status of a grid square on the battle grid. It includes the following values:

Empty: Indicates an empty square.
Ship: Represents a square containing a ship.
Hit: Represents a square that has been hit by the player.
Miss: Represents a square where the player's shot missed the target.

<h2>Usage</h2>

Create an instance of the GameController class.
Call the PlayGame() method to start the game.
Follow the prompts to enter coordinates and take shots on the grid.
The grid will be updated and displayed after each shot.
Continue taking shots until all the ships are sunk.
The game will display a congratulatory message upon winning.

<h2>Example Usage:</h2>

GameController gameController = new GameController();
gameController.PlayGame();

*Note: The game assumes a console-based environment for input and output.*
