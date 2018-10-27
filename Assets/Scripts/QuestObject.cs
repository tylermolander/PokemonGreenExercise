using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour 
{

    //think about what individual quests need to do;
    //set up, engaged (gameobject quest is active, unable to start again, reward...

    public int questNumber;
    public QuestManager theQuestManager;

    public string startText;
    public string endText;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
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