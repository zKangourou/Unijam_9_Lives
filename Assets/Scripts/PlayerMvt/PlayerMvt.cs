using UnityEngine;
using System.Collections;

public class PlayerMvt : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float up;
    private Vector3 playerMovement, goUp;
    private Vector3 directionY;
    private float posY_last_frame;
    private bool jump;
    private int nbSauts;
    Collider2D playerCollider;

    void Start ()
    {
        nbSauts = 0;
        goUp = new Vector3(0, up, 0);
        playerCollider = this.GetComponent<Collider2D>();
        //player = this.GetComponent<Player>();
    }
	
	void Update ()
    {
        directionY = new Vector3(0, 0, 0);
        /*
        RaycastHit hit;
        Ray downRay = new Ray(transform.position, playerCollider.bounds.extents.y * Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down, Color.green);
        if (Physics.Raycast(downRay, out hit, playerCollider.bounds.extents.y)) {
            nbSauts = 0;
        }*/
        if (this.gameObject.transform.position.y == posY_last_frame) {
            nbSauts = 0;
        }
        playerMovement = new Vector3(Input.GetAxis("Horizontal"),0,0);		
		jump = Input.GetButton("Jump");
        if (jump && nbSauts==0) {
            directionY = goUp;
            nbSauts += 1;
        }
        this.gameObject.transform.position += (playerMovement + directionY) * speed * Time.deltaTime ;
        posY_last_frame = this.gameObject.transform.position.y;
    }
}
