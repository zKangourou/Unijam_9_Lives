using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueImages : Singleton<DialogueImages> {
    Dictionary<string, Sprite> dico;
    [SerializeField] Sprite none;
    [SerializeField] Sprite cat;
    [SerializeField] Sprite pigeon;
    [SerializeField] Sprite boss;
    [SerializeField] Sprite girl;

    void Awake()
    {
        dico = new Dictionary<string, Sprite>();
        dico.Add("cat", cat);
        dico.Add("pigeon", pigeon);
        dico.Add("boss", boss);
        dico.Add("girl", girl);
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
