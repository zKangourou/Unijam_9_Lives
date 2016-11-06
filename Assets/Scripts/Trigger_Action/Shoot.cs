using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject laser;
    public GameObject laser2;
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
        //Debug.Log(GetComponent<Rigidbody2D>().velocity);
        //Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMvt>().avance);
        if (!player.isTalking)
        {
            tir = Input.GetKeyDown(KeyCode.Alpha1);
            if (tir && canShoot)
            {

                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMvt>().avance > 0)
                {
                    Debug.Log("devant");
                    Instantiate(laser, player.transform.position, new Quaternion(0, 0, 0, 0));
                }
                else
                {
                    Debug.Log("derrière");
                    Instantiate(laser2, player.transform.position, new Quaternion(0, 0, 0, 0));
                }
            }
        }
    }
}
