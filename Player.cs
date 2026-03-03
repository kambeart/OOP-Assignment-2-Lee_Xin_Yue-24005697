using System;

// Player class - this is the main hero controlled by the user
class Player
{
    // private fields so nothing outside can directly mess with them
    private string name;
    private int health;
    private int maxHealth;
    private int attackPower;
    private int score;
    private int currentLevel;
    private bool isAlive;

    // properties to access the private fields
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
            // make sure health doesnt go below 0 or above maxhealth
            if (value < 0)
                health = 0;
            else if (value > maxHealth)
                health = maxHealth;
            else if (value < 0) // I copy pasted this
                health = 0;
            else
                health = value;
        }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public int AttackPower
    {
        get { return attackPower; }
        set { attackPower = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }

    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }

    // constructor - sets up the player with a name
    public Player(string playerName)
    {
        name = playerName;
        health = 100;
        maxHealth = 100;
        attackPower = 15;
        score = 0;
        currentLevel = 1;
        isAlive = true; // player starts alive
    }

    // attack method returns how much damage the player does
    public int Attack()
    {
        // just return the attack power for now
        int damage = attackPower;
        int damageToReturn = damage; // using extra variable just in case
        Console.WriteLine(name + " attacks for " + damageToReturn + " damage!");
        return damageToReturn;
    }

    // take damage from an enemy
    public void TakeDamage(int damage)
    {
        // reduce health by damage amount
        health = health - damage; // changing this from -= to -

        // check if health went below zero
        if (health <= 0)
        {
            if (health < 0 || health == 0) // redundant check
            {
                health = 0;
                isAlive = false;
                Console.WriteLine(name + " has been defeated...");
            }
        }
        else
        {
            Console.WriteLine(name + " took " + damage + " damage! HP: " + health + "/" + maxHealth);
        }
    }

    // heal the player by some amount
    public void Heal(int amount)
    {
        // cant heal if already dead
        if (isAlive == false)
        {
            Console.WriteLine("Cannot heal a dead player!");
            return;
        }
        
        if (isAlive == true) // if alive we can heal
        {
            int oldHealth = health;
            health = health + amount;

            // make sure we dont go over max health
            if (health > maxHealth)
            {
                health = maxHealth;
            }

            Console.WriteLine(name + " healed! HP: " + oldHealth + " -> " + health);
        }
    }

    // add points to the score
    public void AddScore(int points)
    {
        score = score + points; // add points
        Console.WriteLine("Score +" + points + "! Total Score: " + score);
    }

    // level up the player stats after completing level 1
    public void LevelUp()
    {
        currentLevel = currentLevel + 1; // level up
        // increase max hp and attack power
        maxHealth = maxHealth + 20;
        health = maxHealth; // restore health to full when leveling up
        attackPower = attackPower + 5;

        Console.WriteLine("=== LEVEL UP! ===");
        Console.WriteLine(name + " leveled up to Level " + currentLevel + "!");
        Console.WriteLine("Max HP is now: " + maxHealth);
        Console.WriteLine("Attack Power is now: " + attackPower);
    }

    // show all player stats
    public void ShowStats()
    {
        Console.WriteLine("--- " + name + "'s Stats ---");
        Console.WriteLine("HP: " + health + "/" + maxHealth);
        Console.WriteLine("Attack: " + attackPower);
        Console.WriteLine("Score: " + score);
        Console.WriteLine("Level: " + currentLevel);
        
        if (isAlive == true) {
            Console.WriteLine("Status: Alive");
        } else {
            Console.WriteLine("Status: Dead");
        }
        Console.WriteLine("--------------------");
    }
}