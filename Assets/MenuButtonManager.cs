using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour {

	public void Load()
    {
        SceneManager.LoadScene("Game");
    }
}
