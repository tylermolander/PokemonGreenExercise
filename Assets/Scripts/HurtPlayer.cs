﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public int damageToGive;
    int currentDamage;
    public GameObject damageNumber ;

    PlayerStats thePlayerStats;

	void Start () 
	{
	    thePlayerStats = FindObjectOfType<PlayerStats>();

	}
	
	void Update () 
	{
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            currentDamage = damageToGive - thePlayerStats.currentDefense;

            if (currentDamage < 0)
            {
                currentDamage = 0;
            }
            
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);

            var clone = (GameObject) Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero)); 
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage; 

        }
    }
}
