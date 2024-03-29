using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    private Message[] currentMessages;
    private Actor[] currentActors;
    private int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDiologue(Message [] messages, Actor[] actors) {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        isActive = true;
        Debug.Log("Started conversation! Loaded messages: " + messages.Length);
        DisplayMessage();

        backgroundBox.LeanScale(Vector3.one, 0.5f);
    }

    void DisplayMessage() {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
        AnimateTextColor();
    }

    public void NextMessage() {
        activeMessage++;
        if(activeMessage < currentMessages.Length) {
            DisplayMessage();
        }else {
            Debug.Log("Conversation ended");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseOutExpo();
            isActive = false;
        }
    }

    void AnimateTextColor() {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    // Start is called before the first frame update
    void Start(){
        backgroundBox.transform.localScale = Vector3.zero;
    }

    public void endDialogue()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isActive == true) {
            NextMessage();
        }
    }
}
