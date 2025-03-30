using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [HideInInspector]public static DialogueManager instance;
    public TextMeshProUGUI NPCName, dialogueText;
    private Queue<string> sentences;

    public Animator anim;

    public GameObject DialogueBox;
    public bool inDialogue = false;

     private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update(){
        if (inDialogue && Input.GetKeyDown(KeyCode.R))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue){
        Debug.Log("Funciona");
        DialogueBox.SetActive(true);
        anim.SetBool("IsOpen", true);
        NPCName.text = dialogue.NPCName;
        sentences.Clear();
        inDialogue = true;
        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
       
    }

    public void DisplayNextSentence() {
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text+=letter;
            yield return null;

        }
    }

    public void EndDialogue(){
        Debug.Log("End of convo");
        inDialogue = false;
        anim.SetBool("IsOpen", false);
    }
  
}
