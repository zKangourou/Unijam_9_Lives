using UnityEngine;
using System.Collections;

public class DeathScreenPatern{
    public string deathType;
    public string deathDescription;
    public string deathPowerDescription;

    public DeathScreenPatern()
    {
        deathType = "";
        deathDescription = "";
        deathPowerDescription = "";
    }

    public DeathScreenPatern(string deathTypeIn, string deathDescriptionIn,string deathPowerDescriptionIn)
    {
        deathType = deathTypeIn;
        deathDescription = deathDescriptionIn;
        deathPowerDescription = deathPowerDescriptionIn;
    }
}
