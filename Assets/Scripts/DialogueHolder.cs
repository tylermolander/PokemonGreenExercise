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
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (!dMAn.dialogActive)
                {
                    dMAn.dialogLines = dialogueLines;
                    dMAn.currentLine = 0;
                    dMAn.ShowDialogue();
                }

                if (transform.parent.GetComponent<VillagerMovement>() != null) //during a dialouge event, if the parent has a movement script...
                {
                    transform.parent.GetComponent<VillagerMovement>().canMove = false; //...stop the parent's movement

                }

            }
        }
    }
}
