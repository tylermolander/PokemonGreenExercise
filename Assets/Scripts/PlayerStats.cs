using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if(currentExp >= toLevelUp[currentLevel]) //if current exp is >= the array value at point: current level?
		{
		    currentLevel++;
		}
	}

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }
}
