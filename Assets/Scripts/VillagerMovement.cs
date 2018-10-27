using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D myRigidbody2D;

    public bool isWalking;
    public float walkTime;
    float walkCounter;
    public float waitTime;
    float waitCounter;

	void Start ()
	{
	    myRigidbody2D = GetComponent<Rigidbody2D>();
	    waitCounter = waitTime;
	    walkCounter = walkTime;
	}
	
	void Update () {
		
	}
}
