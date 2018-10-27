using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    public float speed;
    private Animator animator;
    bool playerMoving;
    Vector2 lastMove;
    private Rigidbody2D myRigidbody; //use rigidbody to stop bouncing

	void Start ()
	{
	    animator = GetComponent<Animator>();
	    myRigidbody = GetComponent<Rigidbody2D>();

	}
	
	void Update ()
	{
	    playerMoving = false;

    
       	if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f ||
            Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
	    {
        	 myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
            
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

        
        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
	    animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
	    animator.SetBool("PlayerMoving", playerMoving);
	    animator.SetFloat("LastMoveX", lastMove.x);
	    animator.SetFloat("LastMoveY", lastMove.y);
	}
}
