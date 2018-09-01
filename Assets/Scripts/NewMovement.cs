using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    public float speed;
    private Animator animator;
    bool playerMoving;
    Vector2 lastMove;

	void Start ()
	{
	    animator = GetComponent<Animator>();
	}
	
	void Update ()
	{
	    playerMoving = false;

	    if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f ||
	        Input.GetAxisRaw("Vertical") > 0.5f   || Input.GetAxisRaw("Vertical") < -0.5f)
	    {
	        transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 
	                                        Input.GetAxisRaw("Vertical")   * speed * Time.deltaTime, 0f));
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            playerMoving = true;
	    }
        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
	    animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
	    animator.SetBool("PlayerMoving", playerMoving);
	    animator.SetFloat("LastMoveX", lastMove.x);
	    animator.SetFloat("LastMoveY", lastMove.y);
	}
}
