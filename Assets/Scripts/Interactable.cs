using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Interactable : MonoBehaviour, IRaycastable
{
    [SerializeField] GameObject interactionUI = null;
    [SerializeField] List<Interaction> interactions = new List<Interaction>();

    private void Start() 
    {
        PopulateInteractionEvents();
    }

    private void PopulateInteractionEvents()
    {
        foreach(Interaction interaction in interactions)
        {
            interaction.button.onClick.AddListener(() => TriggerSpeechEvent(interaction.id));

            if (interaction.id == "decrypt" && GetComponentInChildren<CryptoBook>() != null)
            {
                interaction.button.onClick.AddListener(() => GetComponentInChildren<CryptoBook>().TriggerCryptoEvent());
            }
        }
    }

    public void TriggerInteractionEvent()
    {
        interactionUI.SetActive(true);
    }

    public void TriggerSpeechEvent(string vocalPromptID)
    {
        Speech speech = FindObjectOfType<Speech>();

        speech.TriggerVocalPrompt(vocalPromptID);

        CheckForExamineAnimation(vocalPromptID);
    }

    private void CheckForExamineAnimation(string vocalPromptID)
    {
        if (vocalPromptID.EndsWith("Examine"))
        {
            GetComponent<Animator>().SetTrigger("Examine");
        }
    }

    public void TriggerInteractionEnd()
    {
        interactionUI.SetActive(false);
    }
}

[System.Serializable]
class Interaction 
{
    public string id = null;
    public Button button = null;
}