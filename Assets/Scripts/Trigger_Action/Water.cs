using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale /= 4;
        }
    }

    void OnTrigger2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMvt>().ResetJump();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale *= 4;
        }
    }
}
