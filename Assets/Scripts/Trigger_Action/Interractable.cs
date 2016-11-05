using UnityEngine;
using System.Collections;

public class Interractable : MonoBehaviour {
    protected Player player;
    public bool done;

    void Start()
    {
        done = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Interract()
    {

    }
}
