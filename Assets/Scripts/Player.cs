using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Update is called once per frame
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

        if (hit.collider.tag == "Interactable")
        {
            Debug.Log(hit.collider.gameObject.name + " has been triggered.");
        }
    }
    
    private static Vector2 GetMouseRay()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
