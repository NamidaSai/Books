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
            interaction.button.onClick.AddListener(() => TriggerInteractionAnimation(interaction.animationTrigger));

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
    }

    public void TriggerInteractionEnd()
    {
        interactionUI.SetActive(false);
    }

    public void TriggerInteractionAnimation(string animationTrigger)
    {
        if (animationTrigger == "") { return; }
        GetComponent<Animator>().SetTrigger(animationTrigger);
    }

    public void DisableCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }
}

[System.Serializable]
class Interaction 
{
    public string id = null;
    public Button button = null;
    public string animationTrigger = null;
}