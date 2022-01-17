using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    public bool isItem;
    public bool isEquipment;
    public bool isEnemy;
    public bool isNPC;
    public bool isChest;

    [HideInInspector]
    public bool chestInRange = false;
    public bool inRange = false;
    [HideInInspector]
    public bool hasInteracted = false;

    #region Player Ref
    PlayerManager player;
    Transform playerTransform;

    public void Start()
    {
        player = PlayerManager.instance;
        playerTransform = player.player.transform;
    }
    #endregion

    public virtual void Interact()
    {
        // This method is meant to be overwritten
    }

    void Update()
    {
        if(isItem || isEquipment)
        {
            float distance = Vector2.Distance(playerTransform.position, interactionTransform.position);
            
            if(distance <= radius)
            {
                Interact();
            }
        }

        if(isNPC)
        {
            float distance = Vector2.Distance(playerTransform.position, interactionTransform.position);

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

        if(isChest)
        {
            float distance = Vector2.Distance(playerTransform.position, interactionTransform.position);

            if (distance <= radius)
            {
                chestInRange = true;
                Interact();
            }
            else
            {
                chestInRange = false;
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
