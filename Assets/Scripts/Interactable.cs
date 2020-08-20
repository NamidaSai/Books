using UnityEngine;

public class Interactable : MonoBehaviour, IRaycastable
{
    public void OnClickEvent()
    {
        Debug.Log(gameObject.name + " has been clicked.");
    }

}