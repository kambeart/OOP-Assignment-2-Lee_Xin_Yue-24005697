using System;

// Goblin class inherits from Enemy
// goblins appear in level 1 (Dark Forest)
class Goblin : Enemy
{
    // goblin specific field
    private bool canStealGold;

    public bool CanStealGold
    {
        get { return canStealGold; }
        set { canStealGold = value; }
    }

    // constructor for goblin
    // goblins are weak enemies so low hp and attack
    public Goblin(string goblinName) : base(goblinName, 40, 8, 50)
    {
        // all goblins can steal gold by default
        canStealGold = true;
    }

    // special goblin ability - steals score points from player
    public void StealGold(Player player)
    {
        // only steal if goblin is alive and can steal
        if (canStealGold == true && IsAlive == true)
        {
            int stolenAmount = 10; // steals 10 points
            player.Score -= stolenAmount;

            // make sure score doesnt go below 0
            if (player.Score < 0)
            {
                player.Score = 0;
            }

            Console.WriteLine(Name + " stole " + stolenAmount + " gold from " + player.Name + "!");
        }
    }
}
