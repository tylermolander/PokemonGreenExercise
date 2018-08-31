using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{

    Vector3 pos; 
    public float speed = 2.0f;
    Animator myAnimator;

    void Start()
    {
        pos = transform.position; 
        myAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position == pos)
        {
            pos += Vector3.left;
            myAnimator.SetFloat("WalkLeft", 1f);
        }        
        if (!Input.GetKey(KeyCode.LeftArrow) && transform.position == pos)
        {
            myAnimator.SetFloat("WalkLeft", 0f);
        }     
        

        if (Input.GetKey(KeyCode.RightArrow) && transform.position == pos)
        {
            pos += Vector3.right;
            myAnimator.SetBool("WalkRight", true);
        }        
        if (!Input.GetKey(KeyCode.RightArrow) && transform.position == pos)
        {
            myAnimator.SetBool("WalkRight", false);
        }     


        if (Input.GetKey(KeyCode.UpArrow) && transform.position == pos)
        {
            pos += Vector3.up;
            myAnimator.SetBool("WalkUp", true);
        }        
        if (!Input.GetKey(KeyCode.UpArrow) && transform.position == pos)
        {
            myAnimator.SetBool("WalkUp", false);
        }     


        if (Input.GetKey(KeyCode.DownArrow) && transform.position == pos)
        {
            pos += Vector3.down;
            myAnimator.SetBool("WalkDown", true);

        }
        if (!Input.GetKey(KeyCode.DownArrow) && transform.position == pos)
        {
            myAnimator.SetBool("WalkDown", false);
        } 


        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed); 


    }
}