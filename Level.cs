using System;

// Level class stores info about each level in the game
class Level
{
    // private fields
    private int levelNumber;
    private string levelName;
    private string description;
    private bool isCompleted;
    private int enemyCount;

    // properties for all fields
    public int LevelNumber
    {
        get { return levelNumber; }
        set { levelNumber = value; }
    }

    public string LevelName
    {
        get { return levelName; }
        set { levelName = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public bool IsCompleted
    {
        get { return isCompleted; }
        set { isCompleted = value; }
    }

    public int EnemyCount
    {
        get { return enemyCount; }
        set { enemyCount = value; }
    }

    // constructor
    public Level(int number, string name, string desc, int enemies)
    {
        levelNumber = number;
        levelName = name;
        description = desc;
        isCompleted = false; // level starts as not completed
        enemyCount = enemies;
    }

    // displays level info to the player before starting
    public void ShowLevelInfo()
    {
        Console.WriteLine("\n==============================");
        Console.WriteLine("LEVEL " + levelNumber + ": " + levelName);
        Console.WriteLine("==============================");
        Console.WriteLine(description);
        Console.WriteLine("Enemies to defeat: " + enemyCount);
        Console.WriteLine("==============================\n");
    }

    // marks the level as completed
    public void CompleteLevel()
    {
        isCompleted = true;
        Console.WriteLine("\n*** Level " + levelNumber + " - " + levelName + " COMPLETED! ***");
    }
}
