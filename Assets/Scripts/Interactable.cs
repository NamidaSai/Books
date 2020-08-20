using UnityEngine;

public class Interactable : MonoBehaviour, IRaycastable
{
    public void TriggerInteractionEvent()
    {
        Debug.Log(gameObject.name + " has been interacted with.");
    }

}