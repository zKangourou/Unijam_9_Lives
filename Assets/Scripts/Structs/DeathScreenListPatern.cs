using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathScreenListPatern{
    public List<DeathScreenPatern> list;

    public DeathScreenListPatern()
    {
        list = new List<DeathScreenPatern>();
    }

    public DeathScreenListPatern(List<DeathScreenPatern> val)
    {
        list = val;
    }
}
