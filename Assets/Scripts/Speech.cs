using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speech : MonoBehaviour
{
    [SerializeField] DialogueCollection dialogue = null;
    [SerializeField] TextMeshProUGUI speechDisplay = null;

    public void TriggerVocalPrompt(string promptID)
    {
        speechDisplay.text = dialogue.GetVocalPromptText(promptID);
    }
}
