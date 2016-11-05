using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerIcones : Singleton<PowerIcones>
{
    Dictionary<string, Sprite> dico;
    [SerializeField]    Sprite none;

    void Awake()
    {
        dico = new Dictionary<string, Sprite>();
    }


    public static Sprite GetImage(string val)
    {
        return Instance.InstanceGetImage(val);
    }
    Sprite InstanceGetImage(string val)
    {
        if (dico.ContainsKey(val))
        {
            return dico[val];
        }
        else
        {
            return none;
        }
    }
}
