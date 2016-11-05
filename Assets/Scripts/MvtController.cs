using UnityEngine;
using System.Collections;

public class MvtController : MonoBehaviour
{
    //[SerializeField]
    private float speed;
    private Vector2 playerMovement;
    private Vector3 direction;
	private bool saut;

	void Start ()
    {
        //chat = this.GetComponent<Chat>();
    }
	
	void Update ()
    {
        playerMovement = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));		
		saut = Input.GetButton("Espace");
        this.gameObject.transform.position += direction * speed * Time.deltaTime;
    }
}
