using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextesDictionary : Singleton<TextesDictionary> {
    Dictionary<string, string> dialogues;

    void Start()
    {
        dialogues = new Dictionary<string, string>();
        /*DialogueListPatern dialogueListPatern = XmlHelpers.LoadFromTextAsset<DialogueListPatern>(Resources.Load<TextAsset>("dialogues"));
        foreach (DialoguePatern val in dialogueListPatern.list)
        {
            dialogues.Add(val.key,val.text);
        }*/
        DialogueListPatern tmp = new DialogueListPatern();
        tmp.list.Add(new DialoguePatern("exemple_de_cle", "exemple de texte"));
        tmp.list.Add(new DialoguePatern("exemple_de_cle2", "exemple de texte2"));
        XmlHelpers.SaveToXML<DialogueListPatern>("C:/Users/simon/Desktop/dialogues.xml",tmp);
    }

    /// <summary>
    /// renvoi le texte associé à la clé ou la clé si elle n'est pas dans de dico
    /// </summary>
    /// <param name="val">clé pour la recherche</param>
    /// <returns>texte associé à la clé ou la clé si elle n'est pas dans de dico</returns>
    public static string GetTexte(string val)
    {
        return Instance.InstanceGetText(val);
    }
    
    string InstanceGetText(string val)
    {
        if (dialogues.ContainsKey(val))
        {
            return dialogues[val];
        }
        else
        {
            return val;
        }
    }
}
