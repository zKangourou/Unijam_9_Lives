using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject laser;
    public bool canShoot;
    private Player player;
    private bool tir;

    // Use this for initialization
    void Start () {
        player = this.GetComponent<Player>();
        canShoot = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!player.isTalking)
        {
            tir = Input.GetKeyDown(KeyCode.Alpha1);
            if (tir && canShoot)
            {
                Instantiate(laser, player.transform.position, new Quaternion(0,0,0,0));
            }
        }
    }
}
