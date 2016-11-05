using UnityEngine;
using System.Collections;

public class DeathScreenPatern{
    public Player.Death deathType;
    public DeathPatern deathDescription;

    public DeathScreenPatern()
    {
        deathType = Player.Death.barbecue;
        deathDescription = new DeathPatern();
    }

    public DeathScreenPatern(Player.Death deathTypeIn,DeathPatern deathDescriptionIn)
    {
        deathType = deathTypeIn;
        deathDescription = deathDescriptionIn;
    }
}

public class DeathPatern
{
    public string deathDescription;
    public string deathPowerDescription;

    public DeathPatern()
    {
        deathDescription = "";
        deathPowerDescription = "";
    }

    public DeathPatern(string deathDescriptionIn, string deathPowerDescriptionIn)
    {
        deathDescription = deathDescriptionIn;
        deathPowerDescription = deathPowerDescriptionIn;
    }
}