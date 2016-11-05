using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerIcones : Singleton<PowerIcones>
{
    Dictionary<Player.Death, Sprite> dico;
    [SerializeField] Sprite none;
    [SerializeField] Sprite chute;
    [SerializeField] Sprite ecrase_actif;
    [SerializeField] Sprite electro_actif;
    [SerializeField] Sprite electro_passif;
    [SerializeField] Sprite fire_actif;
    [SerializeField] Sprite fire_passif;
    [SerializeField] Sprite noyade_actif;
    [SerializeField] Sprite noyade_passif;
    [SerializeField] Sprite strangle_passif;

    void Awake()
    {
        dico = new Dictionary<Player.Death, Sprite>();
        dico.Add(Player.Death.chute, chute);
        dico.Add(Player.Death.voiture, ecrase_actif);
        dico.Add(Player.Death.tazer, electro_actif);
        dico.Add(Player.Death.lanceFlamme, fire_actif);
        dico.Add(Player.Death.barbecue, fire_passif);
        dico.Add(Player.Death.noyadeActive, noyade_actif);
        dico.Add(Player.Death.noyadePassive, noyade_passif);
        dico.Add(Player.Death.pendaison, strangle_passif);
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
