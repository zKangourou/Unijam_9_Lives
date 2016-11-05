using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerIcones : Singleton<PowerIcones>
{
    Dictionary<Player.Death, Sprite> dico;
    [SerializeField] Sprite none;
    [SerializeField] Sprite chute;
    //[SerializeField] Sprite none;

    void Awake()
    {
        dico = new Dictionary<Player.Death, Sprite>();
        dico.Add(Player.Death.chute, chute);
    }


    public static Sprite GetImage(Player.Death val)
    {
        return Instance.InstanceGetImage(val);
    }
    Sprite InstanceGetImage(Player.Death val)
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
