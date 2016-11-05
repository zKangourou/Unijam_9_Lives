using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextesDictionary : Singleton<TextesDictionary> {
    Dictionary<string, List<DialogueElementPatern>> dialogues;

    void Awake()
    {
        dialogues = new Dictionary<string, List<DialogueElementPatern>>();
        DialogueListPatern dialogueListPatern = XmlHelpers.LoadFromTextAsset<DialogueListPatern>(Resources.Load<TextAsset>("dialogues"));
        foreach (DialoguePatern val in dialogueListPatern.list)
        {
            dialogues.Add(val.key,val.elements);
        }
        /*DialogueListPatern tmp = new DialogueListPatern();
        List<DialogueElementPatern> truc = new List<DialogueElementPatern>();
        truc.Add(new DialogueElementPatern("exemple_d_image", "exemple_de_texte"));
        truc.Add(new DialogueElementPatern("exemple_d_image2", "exemple_de_texte2"));
        DialoguePatern machin = new DialoguePatern("exemple_de_cle",truc);
        tmp.list.Add(machin);
        XmlHelpers.SaveToXML<DialogueListPatern>("C:/Users/simon/Desktop/dialogues.xml",tmp);*/
    }

    /// <summary>
    /// renvoi le texte associé à la clé ou la clé si elle n'est pas dans de dico
    /// </summary>
    /// <param name="val">clé pour la recherche</param>
    /// <returns>texte associé à la clé ou la clé si elle n'est pas dans de dico</returns>
    public static List<DialogueElementPatern> GetTexte(string val)
    {
        return Instance.InstanceGetText(val);
    }

    List<DialogueElementPatern> InstanceGetText(string val)
    {
        if (dialogues.ContainsKey(val))
        {
            return dialogues[val];
        }
        else
        {
            Debug.LogError("La clé "+val+" n'existe pas");
            return new List<DialogueElementPatern>();
        }
    }
}
