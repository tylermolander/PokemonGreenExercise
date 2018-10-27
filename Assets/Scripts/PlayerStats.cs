using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    //TODO: when level up, gain special abilities and unlock areas, etc. 

    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;

    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenseLevels;

    public int currentHP;
    public int currentAttack;
    public int currentDefense;

    PlayerHealthManager thePlayerHealth;

	void Start ()
	{
	    currentHP = HPLevels[1];
	    currentAttack = attackLevels[1];
	    currentDefense = defenseLevels[1];

	    thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
	}
	
	void Update () 
	{
		if(currentExp >= toLevelUp[currentLevel]) //if current exp is >= the array value at point: current level?
		{
		    LevelUp();
		}
	}

    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];

        thePlayerHealth.playerMaxHealth = currentHP; 
        thePlayerHealth.playerCurrentHealth += currentHP - HPLevels[currentLevel - 1]; //adds on the difference between current HP max and previous HP max, adds onto the current HP

        currentAttack = attackLevels[currentLevel];
        currentDefense = defenseLevels[currentLevel];
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }
}
