using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{

    public float moveSpeed;
    Vector2 minWalkPoint;
    Vector2 maxWalkPoint;

    Rigidbody2D myRigidbody2D;

    public bool isWalking;
    public float walkTime;
    float walkCounter;
    public float waitTime;
    float waitCounter;

    int WalkDirection;

    public Collider2D walkZone;

    bool hasWalkZone;
 

	void Start ()
	{
	    myRigidbody2D = GetComponent<Rigidbody2D>();

	    waitCounter = waitTime;
	    walkCounter = walkTime;

        ChooseDirection();

	    if (walkZone != null) // if the walk zone has something in it, then get the boundaries from it.
	    {
	        minWalkPoint = walkZone.bounds.min;
	        maxWalkPoint = walkZone.bounds.max;
	        hasWalkZone = true;
	    }
	}
	
	void Update () 
	{
	    if (isWalking)
	    {
	        walkCounter -= Time.deltaTime;

	        switch (WalkDirection) //npc can move in these four directions within a trigger area
	        {
                case 0:                    
                    myRigidbody2D.velocity = new Vector2(0, moveSpeed);
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

                case 1:
                    myRigidbody2D.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }break;

                case 2:
                    myRigidbody2D.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }break;

                case 3:
                    myRigidbody2D.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }break;
	        }

	        if (walkCounter < 0)
	        {
	            isWalking = false;
	            waitCounter = waitTime;
	        }
	    }
        else
	    { 
	        waitCounter -= Time.deltaTime;

	        myRigidbody2D.velocity = Vector2.zero;
            
	        if (waitCounter < 0)
	        {
	            ChooseDirection();
	        }
	    }
	}

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4); //four directions for movement: 0, 1, 2, 3. (exclusive max)
        isWalking = true;
        walkCounter = walkTime;
    }
}

