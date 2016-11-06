using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class TexteController : MonoBehaviour {
    public enum DialogueType {NOTHING,DIE,GIRL,BOSS}

    static float SHORT_DELTA_TIME = 0.015f;
    static float DELTA_TIME = 0.1f;
    static float LONG_DELTA_TIME = 0.5f;
    static float WAIT_AT_START = 0.5f;


    [SerializeField] private Text text;
    [SerializeField] private Image image;
    [SerializeField] private GameObject things;
    [SerializeField] private DeathScreenController death;
    [SerializeField] private DialogueImages dialogueImages;
    [SerializeField]
    private EndSceneController end;
    string actualText;
    List<DialogueElementPatern> textList;
    bool skip;
    bool next;

    Player player;

    // Use this for initialization
    void Awake () {
        skip = false;
        next = false;
        text.text = "";
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void StartDialogue(string key, DialogueType dialogueType, Player.Death deathType = Player.Death.barbecue)
    {
        player.isTalking = true;
        textList = TextesDictionary.GetTexte(key);
        if (textList.Count ==0)
        {
            Debug.Log("Le dialogue n'a pas de composants");
        }
        things.SetActive(true);
        StartCoroutine(PrintText(dialogueType, deathType));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(skip)
            {
                next = true;
            }
            else
            {
                skip = true;
            }
        }
    }

    IEnumerator PrintText(DialogueType dialogueType, Player.Death deathType)
    {
        for (int i = 0;i<textList.Count;i++)
        {
            actualText = textList[i].text;
            image.sprite = dialogueImages.GetImage(textList[i].image);
            skip = false;
            text.text = "";
            yield return new WaitForSeconds(WAIT_AT_START);
            foreach (char c in actualText)
            {
                text.text += c;
                if (!skip) 
                {
                    yield return new WaitForSeconds(SHORT_DELTA_TIME);

                    if (c == '.' || c == '!' || c == '?' || c == ';' || c == '\n')
                    {
                        yield return new WaitForSeconds(LONG_DELTA_TIME);
                    }
                    else if (c == ',')
                    {
                        yield return new WaitForSeconds(DELTA_TIME);
                    }
                }
            }
            skip = true;
            next = false;
            while (!next)
            {
                yield return new WaitForSeconds(SHORT_DELTA_TIME);
            }
        }
        things.SetActive(false);

        switch (dialogueType)
        {
            case DialogueType.DIE:
                death.StartDeath(deathType);
                break;
            case DialogueType.BOSS:
                end.GameOver();
                break;
            case DialogueType.NOTHING:
            default:
                player.isTalking = false;
                break;
        }
    }
}
