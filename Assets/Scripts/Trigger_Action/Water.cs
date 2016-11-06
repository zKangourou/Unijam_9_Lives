using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMvt>().underwater = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMvt>().underwater = false;
        }
    }
}
