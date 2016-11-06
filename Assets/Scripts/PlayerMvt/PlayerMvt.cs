using UnityEngine;
using System.Collections;

public class PlayerMvt : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float waterSpeed = 2f;
    [SerializeField]
    private float up;
    private Vector3 playerMovement;
    private Vector2 goUp;
    private Vector3 directionY;
    private float posY_last_frame;
    private bool jump;
    private int nbSauts;
    Collider2D playerCollider;
    private Player player;
    Animator animateur;

    public bool underwater;

    void Start ()
    {
        nbSauts = 0;
        goUp = new Vector3(0, up, 0);
        playerCollider = this.GetComponent<Collider2D>();
        player = this.GetComponent<Player>();
        animateur = this.GetComponent<Animator>();
        underwater = false;
    }

    void Update()
    {
        if (!player.isTalking)
        {
            directionY = new Vector3(0, 0, 0);
            /*if (this.gameObject.transform.position.y == posY_last_frame)
            {
                nbSauts = 0;
            }*/
            playerMovement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            if(animateur != null)
            {
                animateur.SetFloat("Avance", playerMovement.x);
            }
            jump = Input.GetButton("Jump");
            if (jump && (nbSauts == 0||underwater))
            {
                if (underwater)
                {
                    GetComponent<Rigidbody2D>().velocity = waterSpeed/speed*goUp;
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = goUp;
                }
                nbSauts += 1;
                if(animateur != null)
                {
                    animateur.SetBool("Jump", true);
                }
            }
            if(underwater && GetComponent<Rigidbody2D>().velocity.y < -waterSpeed / speed)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Mathf.Sign(GetComponent<Rigidbody2D>().velocity.y) * waterSpeed / speed*up/2);
            }
            
            float tmpSpeed = underwater ? waterSpeed : speed;
            this.gameObject.transform.position += (playerMovement + directionY) * tmpSpeed * Time.deltaTime;
            posY_last_frame = this.gameObject.transform.position.y;
            if (animateur != null)
            {
                animateur.SetFloat("Saut", GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D val)
    {
        if(val.gameObject.tag == "Ground")
        {
            nbSauts = 0;
            if (animateur != null)
            {
                animateur.SetBool("Jump", false);
            }
        }
    }

    public void ResetJump()
    {
        nbSauts = 0;
    }
}
