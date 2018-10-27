using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    //attached to objects that the player can pick up & are part of a quest.

    public int questNumber;
    QuestManager theQM;
    public string itemName;


	void Start ()
	{
	    theQM = FindObjectOfType<QuestManager>();
	}
	
	void Update () 
	{
		  
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!theQM.questCompleted[questNumber] && theQM.quests[questNumber].gameObject.activeSelf)
            {
                theQM.itemCollected = itemName;
                gameObject.SetActive(false);
            }
        }
    }

}
