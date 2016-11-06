using UnityEngine;
using System.Collections;

public class Piou : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(15,0,0) * Time.deltaTime;
        //GetComponent<Rigidbody2D>().velocity = new Vector3(15,0,0);
    }

    void OnTriggerEnter2D(Collider2D caisse)
    {
        if(caisse.tag == "Player")
        {
            return;
        }
        if (caisse.tag == "Caisse")
        {
            Debug.Log("coucou");
            Debug.Log("pouf");
            GameObject.Destroy(caisse.gameObject);
        }
        if (caisse.gameObject.tag != "Water")
        {
            GameObject.Destroy(this.gameObject);
        }


    }

    void OnCollisionEnter2D(Collision2D caisse)
    {
        if (caisse.gameObject.tag == "Player")
        {
            return;
        }
        if (caisse.gameObject.tag == "Caisse")
        {
            Debug.Log("coucou");
            Debug.Log("pouf");
            GameObject.Destroy(caisse.gameObject);
        }
        Debug.Log(caisse.gameObject.tag);
        if (caisse.gameObject.tag != "Water")
        {
            GameObject.Destroy(this.gameObject);
        }

    }
}
