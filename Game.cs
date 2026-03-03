using System;

// Game class controls the overall game flow
// this is like the main controller of everything
class Game
{
    // private fields
    private Player player; // I think I need this
    private bool gameOver;
    private bool gameWon;
    private int totalLevels;

    // properties
    public Player Player
    {
        get { return player; }
        set { player = value; }
    }

    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    public bool GameWon
    {
        get { return gameWon; }
        set { gameWon = value; }
    }

    public int TotalLevels
    {
        get { return totalLevels; }
        set { totalLevels = value; }
    }

    // constructor
    public Game()
    {
        gameOver = false;
        gameWon = false;
        totalLevels = 2; // there are 2 levels in the game
        // fix the annoying green line warning
        player = new Player("nobody yet");   // player gets set up later in SetupPlayer
    }

    // shows the title screen
    public void ShowTitle()
    {
        Console.WriteLine("=========================================");
        Console.WriteLine("        SHADOW DUNGEON RPG               ");
        Console.WriteLine("=========================================");
        Console.WriteLine("  A text-based adventure game            ");
        Console.WriteLine("  Fight your way through the dungeon!    ");
        Console.WriteLine("=========================================");
        Console.WriteLine();
    }

    // gets player name and creates the player object
    public void SetupPlayer()
    {
        Console.Write("Enter your hero's name: ");
        // my friend told me to add ! here to fix the green line
        string playerName = Console.ReadLine()!; // it says warning here but it works fine
        
        if (playerName == null) {
            playerName = ""; // just in case
        }

        // just in case player enters empty name
        if (playerName == "" || playerName == null)
        {
            playerName = "Hero";
        }
        else if (playerName == "") { // double check
             playerName = "Hero";
        }

        player = new Player(playerName);
        Console.WriteLine("\nWelcome, " + player.Name + "! Your adventure begins...\n");
    }

    // runs level 1 - dark forest with 3 goblins
    public void RunLevel1()
    {
        Level level1 = new Level(1, "Dark Forest", "You enter a dark and scary forest. Goblins lurk in the shadows!", 3);
        level1.ShowLevelInfo();

        // create 3 goblins for level 1
        Goblin goblin1 = new Goblin("Forest Goblin");
        Goblin goblin2 = new Goblin("Sneaky Goblin");
        Goblin goblin3 = new Goblin("Big Goblin");

        // fight goblin 1
        Console.WriteLine("\nA goblin jumps out from behind a tree!");
        Battle battle1 = new Battle(player, goblin1);
        bool won1 = battle1.StartBattle();

        // if player lost stop here
        if (player.IsAlive == false)
        {
            if (player.IsAlive == false) // checking again just to be sure
            {
               gameOver = true;
               return;
            }
        }

        // heal a little between fights
        Console.WriteLine("\nYou find a healing potion on the ground!");
        player.Heal(20);

        // fight goblin 2
        Console.WriteLine("\nAnother goblin appears!");
        Battle battle2 = new Battle(player, goblin2);
        bool won2 = battle2.StartBattle();

        if (player.IsAlive == false)
        {
            gameOver = true;
            return;
        }

        // heal again between fights
        Console.WriteLine("\nYou rest for a moment and recover some health.");
        player.Heal(15);

        // fight goblin 3
        Console.WriteLine("\nThe biggest goblin of the forest blocks your path!");
        Battle battle3 = new Battle(player, goblin3);
        bool won3 = battle3.StartBattle();

        if (player.IsAlive == false)
        {
            gameOver = true;
            return;
        }

        // player survived all 3 goblins - level complete
        if (player.IsAlive == true) {
            level1.CompleteLevel();
            player.AddScore(100); // bonus points for completing level
            Console.WriteLine("\nYou cleared the Dark Forest!");
            Console.WriteLine("Bonus score awarded for completing Level 1!");
            
            // level up the player before level 2
            player.LevelUp();
        }

        Console.WriteLine("\nPress Enter to continue to Level 2...");
        Console.ReadLine();
    }

    // runs level 2 - dragons lair with boss dragon
    public void RunLevel2()
    {
        Level level2 = new Level(2, "Dragon's Lair", "You enter the lair of the mighty dragon. This is the final battle!", 1);
        level2.ShowLevelInfo();

        // create the boss dragon
        Dragon bossdragon = new Dragon("Shadow Dragon");

        Console.WriteLine("The Shadow Dragon rises from its treasure pile!");
        Console.WriteLine("It looks VERY powerful. Be careful!");
        Console.WriteLine();

        // fight the dragon
        Battle finalBattle = new Battle(player, bossdragon);
        bool result = finalBattle.StartBattle();

        if (player.IsAlive == false)
        {
            // player died to dragon
            gameOver = true;
            return;
        }

        if (player.IsAlive == true) 
        {
            // player beat the dragon!
            level2.CompleteLevel();
            player.AddScore(300); // big bonus for beating the boss
            gameWon = true;
        }
    }

    // shows the ending screen - win or lose
    public void ShowEnding()
    {
        Console.WriteLine("\n=========================================");

        if (gameWon == true)
        {
            // player won the game
            Console.WriteLine("         CONGRATULATIONS!               ");
            Console.WriteLine("=========================================");
            Console.WriteLine("You defeated the Shadow Dragon and saved");
            Console.WriteLine("the dungeon! You are a true hero!");
            Console.WriteLine();
            Console.WriteLine("Final Score: " + player.Score);
            Console.WriteLine("=========================================");
        }
        else if (gameWon == false) // redundant check
        {
            // player lost the game
            Console.WriteLine("           GAME OVER                    ");
            Console.WriteLine("=========================================");
            Console.WriteLine(player.Name + " has fallen in battle...");
            Console.WriteLine("The dungeon remains dark and dangerous.");
            Console.WriteLine();
            Console.WriteLine("Final Score: " + player.Score);
            Console.WriteLine("Better luck next time!");
            Console.WriteLine("=========================================");
        }
    }

    // main method that runs the whole game
    public void StartGame()
    {
        ShowTitle();
        SetupPlayer();

        // run level 1 first
        RunLevel1();

        // only run level 2 if player survived level 1
        if (gameOver == false)
        {
            if (gameOver != true) { // make sure
                RunLevel2();
            }
        }

        // show the ending no matter what
        ShowEnding();
    }
}