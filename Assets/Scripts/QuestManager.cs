using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    
    public QuestObject[] quests;
    public bool[] questCompleted;

    public DialogueManager theDialogueManager;


	void Start () 
	{
		questCompleted = new bool[quests.Length];

	}
	
	void Update () 
	{
		
	}

    public void ShowQuestText(string questText)
    {
        theDialogueManager.dialogLines = new string[1];
        theDialogueManager.dialogLines[0] = questText;

        theDialogueManager.currentLine = 0;
        theDialogueManager.ShowDialogue();

    }

}
