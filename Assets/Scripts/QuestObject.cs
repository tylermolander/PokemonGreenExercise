﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour 
{
    //attached to each quest-object

    //think about what individual quests need to do;
    //set up, engaged (gameobject quest is active, unable to start again, reward...

    public int questNumber;
    public QuestManager theQuestManager;

    public string startText;
    public string endText;

    public bool isItemQuest;
    public string targetItem;

    public bool isEnemyQuest;
    public string targetEnemy;
    public int enemiesToKill;
    int enemyKillCount;
    
	void Start () 
	{
		
	}
	
	void Update () 
	{
	    if(isItemQuest)
	    {
	        if (theQuestManager.itemCollected == targetItem)
	        {
	            theQuestManager.itemCollected = null;

	            EndQuest();
	        }
	    }

	    if (isEnemyQuest)
	    {
	        if (theQuestManager.enemyKilled == targetEnemy)
	        {
	            theQuestManager.enemyKilled = null;
	            enemyKillCount++;
	        }

	        if (enemyKillCount >= enemiesToKill)
	        {
                EndQuest();
	        }
	    }
	}

    public void StartQuest()
    {
        theQuestManager.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        theQuestManager.ShowQuestText(endText);
        theQuestManager.questCompleted[questNumber] = true;  
        gameObject.SetActive(false);

    }
}