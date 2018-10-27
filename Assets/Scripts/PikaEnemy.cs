using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public float waitToReload;
    bool reloading = false;
    GameObject thePlayer;

	void Start ()
	{
	    myRigidbody = GetComponent<Rigidbody2D>();

	    //timeBetweenMoveCounter = timeBetweenMove;
	    //timeToMoveCounter = timeToMove;


	    timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); //whatever timebetweenmove is, it's between 3/4 and 1&1/4
	    timeToMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
	}
	
	void Update () 
	{
	    if (moving)
	    {
	        timeToMoveCounter -= Time.deltaTime;
	        myRigidbody.velocity = moveDirection;

	        if (timeToMoveCounter < 0f)
	        {
	            moving = false;
	            //timeBetweenMoveCounter = timeBetweenMove;
	            timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); 

	        }
	    }
	    else
	    {
	        timeBetweenMoveCounter -= Time.deltaTime;
	        myRigidbody.velocity = Vector2.zero;

	        if (timeBetweenMoveCounter < 0f)
	        {
	            moving = true;
	            //timeToMoveCounter = timeToMove;
	            timeToMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);


                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f,1f) * moveSpeed, 0f);
	        }
	    }

	    if (reloading)
	    {
	        waitToReload -= Time.deltaTime; //will keep counting down?
	        if (waitToReload < 0)
	        {
	            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload this level
                thePlayer.SetActive(true);
	        }
	    }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        /*if (other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            reloading = true;
            thePlayer = other.gameObject; // the player is set to the thing that the enemy collided with
        }*/



    }

}
