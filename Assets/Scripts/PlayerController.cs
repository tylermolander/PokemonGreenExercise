using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Animator anim;
    bool playerMoving;
    public Vector2 lastMove;

    private Rigidbody2D myRigidbody; //use rigidbody to stop bouncing

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    static bool playerExists;

    public string startPoint;

	void Start ()
	{
	    anim = GetComponent<Animator>();
	    myRigidbody = GetComponent<Rigidbody2D>();

	    if (!playerExists)
	    {
	        playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
	    }
	    else
	    {
            Destroy(gameObject);
	    }

	}
	
	void Update ()
	{
	    playerMoving = false;

	    if (!attacking)
	    {


	        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f ||
	            Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
	        {
	            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed,
	                                               Input.GetAxisRaw("Vertical") * speed);
	            playerMoving = true;
	            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	        }

	        if (Input.GetAxisRaw("Horizontal") < 0.5 && Input.GetAxisRaw("Horizontal") > -0.5)
	        {
	            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
	        }

	        if (Input.GetAxisRaw("Vertical") < 0.5 && Input.GetAxisRaw("Vertical") > -0.5)
	        {
	            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
	        }


	        if (Input.GetKeyDown(KeyCode.Mouse0))
	        {
	            attackTimeCounter = attackTime;
	            attacking = true;
	            myRigidbody.velocity = Vector2.zero; //freeze position
	            anim.SetBool("Attack", true);
	        }

	    }


	    if (attackTimeCounter > 0)
	    {
	        attackTimeCounter -= Time.deltaTime;
	    }

	    if (attackTimeCounter <= 0)
	    {
	        attacking = false;
            anim.SetBool("Attack", false);
	    }


	    anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
	    anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
	    anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
	    anim.SetFloat("LastMoveY", lastMove.y);
	}
}
