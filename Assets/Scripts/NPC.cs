using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public Dialogue dialogue;
    public Animator animator;
    public NPCAI npcAI;

    public DialogueManager dialogueManager;

    public override void Interact()
    {
        base.Interact();
        if(inRange && !hasInteracted)
        {
            TriggerDialogue();

        }
        else if(!inRange)
        {
            EndDialogue();
        }
    }

    public void TriggerDialogue()
    {
        npcAI.enabled = false;
        hasInteracted = true;
        animator.SetBool("isActive", true);
        dialogueManager.StartDialogue(dialogue);
    }

    public void EndDialogue()
    {
        npcAI.enabled = true;
        hasInteracted = false;
        animator.SetBool("isActive", false);
    }


}
