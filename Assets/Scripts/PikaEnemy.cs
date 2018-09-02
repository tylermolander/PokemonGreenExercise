﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikaEnemy : MonoBehaviour
{
    public float moveSpeed;

    public float timeBetweenMove;
    public float timeToMove;
    private float timeToMoveCounter;   
    private float timeBetweenMoveCounter;

    private Rigidbody2D myRigidbody;
    private bool moving;
    private Vector3 moveDirection;

	// Use this for initialization
	void Start ()
	{
	    myRigidbody = GetComponent<Rigidbody2D>();

	    timeBetweenMoveCounter = timeBetweenMove;
	    timeToMoveCounter = timeToMove;
	}
	
	// Update is called once per frame
	void Update () 
	{
	    if (moving)
	    {
	        timeToMoveCounter -= Time.deltaTime;
	        myRigidbody.velocity = moveDirection;

	        if (timeToMoveCounter < 0f)
	        {
	            moving = false;
	            timeBetweenMoveCounter = timeBetweenMove;
	        }
	    }
	    else
	    {
	        timeBetweenMoveCounter -= Time.deltaTime;
	        myRigidbody.velocity = Vector2.zero;

	        if (timeBetweenMoveCounter < 0f)
	        {
	            moving = true;
	            timeToMoveCounter = timeToMove;
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f,1f) * moveSpeed, 0f);
	        }
	    }
	}
}
