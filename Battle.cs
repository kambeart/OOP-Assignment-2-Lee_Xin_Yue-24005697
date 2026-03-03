using System;

// Battle class handles the turn based combat between player and enemy
class Battle
{
    // private fields
    private Player player;
    private Enemy enemy;
    private bool playerWon;

    // properties
    public Player Player
    {
        get { return player; }
        set { player = value; }
    }

    public Enemy Enemy
    {
        get { return enemy; }
        set { enemy = value; }
    }

    public bool PlayerWon
    {
        get { return playerWon; }
        set { playerWon = value; }
    }

    // constructor - needs a player and enemy to start a battle
    public Battle(Player p, Enemy e)
    {
        player = p;
        enemy = e;
        playerWon = false; // start with false
    }

    // main battle loop
    public bool StartBattle()
    {
        Console.WriteLine("\n=============================");
        Console.WriteLine("BATTLE START!");
        Console.WriteLine(player.Name + " vs " + enemy.Name);
        Console.WriteLine("=============================\n");

        // keep fighting until someone dies
        while (player.IsAlive == true && enemy.IsAlive == true)
        {
            // show options to player
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Check Stats");
            Console.Write("Enter choice: ");

            // teacher said something about warning here so I add this check
            // put exclamation mark so it stops complaining
            string choice = Console.ReadLine()!;
            if (choice == null) {
                choice = "1"; // default attack if null
            }

            if (choice == "1")
            {
                // player attacks first
                int damage = player.Attack();
                enemy.TakeDamage(damage);

                // check if enemy died after player attack
                if (enemy.IsAlive == false)
                {
                    if (enemy.IsAlive == false) // checking twice just in case
                    {
                        playerWon = true;
                        player.AddScore(enemy.ScoreReward);
                        Console.WriteLine("\nYou defeated " + enemy.Name + "!");
                        break;
                    }
                }

                // now its enemy turn
                if (enemy.IsAlive == true) 
                {
                    EnemyTurn();
                }
            }
            else if (choice == "2")
            {
                // just show stats, doesnt count as a turn
                player.ShowStats();
            }
            else
            {
                // invalid input
                Console.WriteLine("Invalid choice, please enter 1 or 2");
            }

            // check if player died after enemy attacked
            if (player.IsAlive == false)
            {
                playerWon = false; // set to false again
                Console.WriteLine("\nGame Over! " + player.Name + " was defeated by " + enemy.Name + "...");
                break; // stop loop
            }
        }

        return playerWon;
    }

    // enemy takes its turn to attack the player
    public void EnemyTurn()
    {
        Console.WriteLine("\n--- Enemy Turn ---");

        // check if enemy is a goblin to use steal ability sometimes
        if (enemy is Goblin)
        {
            Goblin goblin = (Goblin)enemy;
            // goblin randomly decides to steal or attack
            // using a simple check - every other turn it tries to steal
            Random rand = new Random();
            int action = rand.Next(0, 2); // 0 or 1
            
            bool canHeSteal = goblin.CanStealGold;

            if (action == 0 && canHeSteal == true)
            {
                if (canHeSteal == true) { // double check if he can steal
                    goblin.StealGold(player);
                }
            }
            else
            {
                int damage = enemy.Attack();
                player.TakeDamage(damage);
            }
        }
        else if (enemy is Dragon)
        {
            // dragon uses fire breath sometimes
            Dragon dragon = (Dragon)enemy;
            Random rand = new Random();
            int action = rand.Next(0, 3); // 0, 1, or 2

            if (action == 0 && dragon.CanBreatheFire == true)
            {
                if (dragon.CanBreatheFire == true) 
                {
                    // dragon breathes fire!
                    int fireDamage = dragon.BreatheFire();
                    player.TakeDamage(fireDamage);
                }
            }
            else
            {
                // normal attack
                int damage = enemy.Attack();
                player.TakeDamage(damage);
            }
        }
        else
        {
            // normal enemy just attacks
            int damage = enemy.Attack();
            player.TakeDamage(damage);
        }
    }
}