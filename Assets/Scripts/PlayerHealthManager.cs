﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public int playerMaxHealth;
    public int playerCurrentHealth;

	void Start ()
	{
	    playerCurrentHealth = playerMaxHealth;
	}
	
	void Update () 
	{
	    if (playerCurrentHealth <= 0)
	    {
            gameObject.SetActive(false);
	    }
	}

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

}
