using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    public float speed;
    private Animator animator;

	void Start ()
	{
	    animator = GetComponent<Animator>();
	}
	
	void Update () 
	{

	    if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f ||
	        Input.GetAxisRaw("Vertical") > 0.5f   || Input.GetAxisRaw("Vertical") < -0.5f)
	    {
	       transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 
	                                        Input.GetAxisRaw("Vertical")   * speed * Time.deltaTime, 0f));
            animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
	        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

	    }
	}
}
