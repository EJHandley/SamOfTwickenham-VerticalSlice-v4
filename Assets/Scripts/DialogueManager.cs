﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    #region Singleton

    public static DialogueManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public TMP_Text npcName;
    public TMP_Text npcDialogue;

    public NPC npc;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void Update()
    {

    }

    public void StartDialogue(Dialogue dialogue)
    {
        npcName.text = dialogue.name;

            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            npc.EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        npcDialogue.text = sentence;
    }
}