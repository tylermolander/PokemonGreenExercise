using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    QuestManager theQM;
    public int questNumber;

    public bool startQuest;
    public bool endQuest;

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
            if (!theQM.questCompleted[questNumber]) //if the quest hasn't been completed...
            {
                if(startQuest && !theQM.quests[questNumber].gameObject.activeSelf)   //... if X && the quest is inactive ...
                {
                    theQM.quests[questNumber].gameObject.SetActive(true); // ... activate the quest object
                    theQM.quests[questNumber].StartQuest(); //run the quest
                }

                if(endQuest && theQM.quests[questNumber].gameObject.activeSelf)
                {
                    theQM.quests[questNumber].EndQuest(); 
                }
            }
        }
    }

}
