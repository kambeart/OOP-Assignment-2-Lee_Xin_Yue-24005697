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

    public int ScoreReward
    {
        get { return scoreReward; }
        set { scoreReward = value; }
    }

    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }

    // constructor for enemy
    public Enemy(string enemyName, int enemyHealth, int enemyAttack, int reward)
    {
        name = enemyName;
        health = enemyHealth;
        attackPower = enemyAttack;
        scoreReward = reward;
        isAlive = true; // enemies start alive
    }

    // enemy attacks the player and returns damage dealt
    public int Attack()
    {
        int damage = attackPower;
        int totalDamage = damage; // temp var
        Console.WriteLine(name + " attacks for " + totalDamage + " damage!");
        return totalDamage;
    }

    // enemy takes damage from player
    public void TakeDamage(int damage)
    {
        health = health - damage;

        if (health <= 0)
        {
            if (health < 0 || health == 0) // redundant
            {
                health = 0;
                isAlive = false;
                Console.WriteLine(name + " has been defeated! You earn " + scoreReward + " points!");
            }
        }
        else if (health > 0)
        {
            // enemy is still alive, show remaining hp
            Console.WriteLine(name + " took " + damage + " damage! Enemy HP: " + health);
        }
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