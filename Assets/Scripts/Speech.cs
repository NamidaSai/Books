using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speech : MonoBehaviour
{
    [SerializeField] DialogueCollection dialogue = null;
    [SerializeField] GameObject speechDisplay = null;
    [SerializeField] float readingTime = 5f;

    private void Start() 
    {
        speechDisplay.SetActive(false);
    }
    
    public void TriggerVocalPrompt(string promptID)
    {
        speechDisplay.SetActive(true);
        speechDisplay.GetComponentInChildren<TextMeshProUGUI>().text = dialogue.GetVocalPromptText(promptID);
        StartCoroutine(WaitForReadingTime());
    }

    IEnumerator WaitForReadingTime()
    {
        yield return new WaitForSeconds(readingTime);
        speechDisplay.SetActive(false);
    }
}
