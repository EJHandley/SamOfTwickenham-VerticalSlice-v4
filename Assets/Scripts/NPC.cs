using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public Dialogue dialogue;
    public Animator animator;
    public NPCAI npcAI;

    public DialogueManager dialogueManager;

    public bool isLord;

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
        hasInteracted = true;
        animator.SetBool("isActive", true);
        dialogueManager.StartDialogue(dialogue);
        if (isLord)
            return;
        npcAI.enabled = false;
    }

    public void EndDialogue()
    {
        hasInteracted = false;
        animator.SetBool("isActive", false);
        if (isLord)
            return;
        npcAI.enabled = true;
    }


}
