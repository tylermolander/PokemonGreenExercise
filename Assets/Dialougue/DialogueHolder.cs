using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

    public string dialogue;
    DialogueManager dMAn;

    public string[] dialogueLines;

	void Start ()
	{
	    dMAn = FindObjectOfType<DialogueManager>();
	}
	
	void Update () 
	{
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                //dMAn.ShowBox(dialogue);

                if (!dMAn.dialogActive)
                {
                    dMAn.dialogLines = dialogueLines;
                    dMAn.currentLine = 0;
                    dMAn.ShowDialogue();
                }
            }
        }
    }
}
