namespace Battleships.Enums
{
    /// <summary>
    /// This enum will encapsulate all possible statuses for a single grid element on the gameboard
    /// </summary>
    public enum GridSquareStatus
    {
        Unknown,
        Empty,
        Ship,
        Hit,
        Miss
    }
}
