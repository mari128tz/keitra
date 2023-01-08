using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public DialogueTrigger trigger;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") == true)
            trigger.starDialogue();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger.endDialogue();
    }
}
