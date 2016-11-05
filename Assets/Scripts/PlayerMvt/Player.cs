using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    private int life;
    private bool action, go, death_barbecue;
    private List<bool> death_list = new List<bool>();
    //private List<Transform> myList = new List<Transform>();
    //private Dictionary<Deaths, List<Transform>> myDeath;

    void Start () {
        life = 9;
        death_barbecue = false;
        go = false;
        death_list.Add(death_barbecue);
	}
	
	void Update () {
        action = Input.GetButtonDown("Action");
        if (action) { go = true; }
    }

    private void LoseOneLife()
    {
        if (this.life != 0)
        {
            this.life -= 1;
        }
    }

    void OnTrigger2D(Collider2D coll)
    {
        if (go)
        {
            Debug.Log("Action");
            Barbecue barbecue = coll.gameObject.GetComponent<Barbecue>();
            if (barbecue)
            {
                Debug.Log("Le chat brûle et gagne un pouvoir !");
                LoseOneLife();
                death_barbecue = true;
                go = false;
            }
        }
    }
}
