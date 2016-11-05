using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerIcones : MonoBehaviour
{
    Dictionary<Player.Death, Sprite> dico;
    [SerializeField] public Sprite none;
    [SerializeField] public Sprite chute;
    [SerializeField] public Sprite cut_actif;
    [SerializeField] public Sprite cut_Passif;
    [SerializeField] public Sprite ecrase_actif;
    [SerializeField] public Sprite electro_actif;
    [SerializeField] public Sprite electro_passif;
    [SerializeField] public Sprite fire_actif;
    [SerializeField] public Sprite fire_passif;
    [SerializeField] public Sprite glace_actif;
    [SerializeField] public Sprite glace_passif;
    [SerializeField] public Sprite lazer_actif;
    [SerializeField] public Sprite lazer_passif;
    [SerializeField] public Sprite noyade_actif;
    [SerializeField] public Sprite noyade_passif;
    [SerializeField] public Sprite strangle_passif;

    void Awake()
    {
        dico = new Dictionary<Player.Death, Sprite>();
        dico.Add(Player.Death.chute, chute);
        dico.Add(Player.Death.tronconneuse, cut_actif);
        dico.Add(Player.Death.hachoir, cut_Passif);
        dico.Add(Player.Death.voiture, ecrase_actif);
        dico.Add(Player.Death.tazer, electro_actif);
        dico.Add(Player.Death.lanceFlamme, fire_actif);
        dico.Add(Player.Death.barbecue, fire_passif);
        dico.Add(Player.Death.givreActive, glace_actif);
        dico.Add(Player.Death.givrePassive, glace_passif);
        dico.Add(Player.Death.meurtreParBalle, lazer_actif);
        dico.Add(Player.Death.suicideParBalle, lazer_passif);
        dico.Add(Player.Death.noyadeActive, noyade_actif);
        dico.Add(Player.Death.noyadePassive, noyade_passif);
        dico.Add(Player.Death.pendaison, strangle_passif);
    }


    public Sprite GetImage(Player.Death val)
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
