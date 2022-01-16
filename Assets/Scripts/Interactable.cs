using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    public Transform player;

    public bool isItem;
    public bool isEquipment;
    public bool isEnemy;
    public bool isNPC;
    public bool isChest;

    [HideInInspector]
    public bool inRange = false;
    [HideInInspector]
    public bool hasInteracted = false;

    public virtual void Interact()
    {
        // This method is meant to be overwritten
    }

    void Update()
    {
        if(isItem || isEquipment)
        {
            float distance = Vector2.Distance(player.position, interactionTransform.position);
            
            if(distance <= radius)
            {
                Interact();
            }
        }

        if(isNPC)
        {
            float distance = Vector2.Distance(player.position, interactionTransform.position);

            if (distance <= radius)
            {
                inRange = true;
                Interact();
            }
            else
            {
                inRange = false;
                Interact();
            }

        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
