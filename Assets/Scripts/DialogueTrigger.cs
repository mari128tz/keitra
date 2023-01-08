using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    public Message[] messages;
    public Actor[] actors;

    public void starDialogue() {
        FindObjectOfType<DialogueManager>().OpenDiologue(messages, actors);
    }
    public void endDialogue()
    {
        FindObjectOfType<DialogueManager>().endDialogue();
    }

}

[System.Serializable]
public class Message{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor{
    public string name;
    public Sprite sprite;
}