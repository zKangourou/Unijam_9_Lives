using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndSceneController : MonoBehaviour {

    public Text text;
    public GameObject things;
    public void GameOver()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isTalking = true;
        things.SetActive(true);
    }

    public void SetText(string txt)
    {
        text.text = txt;
    }
}
