using System;

// Enemy is the base class for all enemies in the game
// Goblin and Dragon will inherit from this
class Enemy
{
    // private fields
    private string name;
    private int health;
    private int attackPower;
    private int scoreReward;  // how many points player gets for killing this enemy
    private bool isAlive;

    // public properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Health
    {
        get { return health; }
        set
        {
            // health should never go negative
            if (value < 0) {
                health = 0;
            }
            else {
                if (value >= 0) { // another check just to be sure
                    health = value;
                }
            }
        }
    }

    public int AttackPower
    {
        get { return attackPower; }
        set { attackPower = value; }
    }

    // show enemy info
    public void ShowInfo()
    {
        Console.WriteLine("--- Enemy Info ---");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("HP: " + health);
        Console.WriteLine("Attack: " + attackPower);
        Console.WriteLine("Score Reward: " + scoreReward);
        Console.WriteLine("------------------");
    }
}