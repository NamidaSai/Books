using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InteractWithObject();
        }
    }

    private void InteractWithObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(GetMouseRay(), Vector2.zero);

        IRaycastable raycastable = hit.transform.GetComponent<IRaycastable>();
        
        if (raycastable == null)
        {
            Debug.LogWarning("Interactable Object is missing IRaycastable component.");
            return;
        }

        raycastable.OnClickEvent();
        
    }
    
    private static Vector2 GetMouseRay()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
