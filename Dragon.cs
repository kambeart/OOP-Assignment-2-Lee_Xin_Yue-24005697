using System;

// Dragon is the boss enemy in level 2
// inherits from Enemy but is much stronger
class Dragon : Enemy
{
    // dragon specific fields
    private bool canBreatheFire;
    private int fireBreathDamage;

    public bool CanBreatheFire
    {
        get { return canBreatheFire; }
        set { canBreatheFire = value; }
    }

    public int FireBreathDamage
    {
        get { return fireBreathDamage; }
        set { fireBreathDamage = value; }
    }

    // dragon constructor - dragon is a tough boss so high hp and attack
    public Dragon(string dragonName) : base(dragonName, 150, 20, 200)
    {
        canBreatheFire = true;
        fireBreathDamage = 35; // fire breath does extra damage
    }

    // dragon breathes fire on the player - special attack
    public int BreatheFire()
    {
        // dragon can only use fire breath if it has the ability
        if (canBreatheFire == true)
        {
            Console.WriteLine(Name + " breathes FIRE! It deals " + fireBreathDamage + " damage!");
            return fireBreathDamage;
        }
        else
        {
            // fall back to normal attack if cant breathe fire
            Console.WriteLine(Name + " tries to breathe fire but fails!");
            return 0;
        }
    }
}
