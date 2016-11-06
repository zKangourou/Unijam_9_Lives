using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndSceneController : MonoBehaviour {

    public Text text;
    public GameObject things;
    public void GameOver(string txt)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isTalking = true;
        text.text = txt;
        things.SetActive(true);
    }
}
