using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour 
{

	public GameObject player;
    public Transform pos;
    public bool inRoom = true;
    
	void Start()
	{
    	GameObject player = GetComponent<GameObject>();
	    GameObject pos = GetComponent<GameObject>();
    }

    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D()
    {
        if (inRoom)
        {
            print("hitcollider");        
            player.transform.position = pos.position;
            inRoom = false;
            yield return new WaitForSeconds(1f);
            inRoom = true;
        }


    }


 }
