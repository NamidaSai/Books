using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float distanceToInteract = 1f;
    [SerializeField] float moveSpeed = 10f;

    GameObject targetObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleInteract();
        }

        if (targetObject == null) { return; }
        
        HandleMovement();
        ResolveInteraction();
    }

    private void HandleInteract()
    {
        RaycastHit2D hit = Physics2D.Raycast(GetMouseRay(), Vector2.zero);

        if (hit.collider == null) { return; }

        SetTargetObject(hit);
    }

    private void HandleMovement()
    {
        if (Vector2.Distance(transform.position, targetObject.transform.position) >= distanceToInteract)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, step);
        }
    }

    private void SetTargetObject(RaycastHit2D hit) 
    {
        IRaycastable raycastable = hit.transform.gameObject.GetComponent<IRaycastable>();

        if (raycastable == null)
        {
           Debug.LogWarning("Interactable Object is missing IRaycastable component.");
           return;
        }

        targetObject = hit.transform.gameObject;
    }

    private void ResolveInteraction()
    {
        if (Vector2.Distance(transform.position, targetObject.transform.position) <= distanceToInteract)
        {
            targetObject.GetComponent<IRaycastable>().TriggerInteractionEvent();
            targetObject = null;
        }
    }
    
    private static Vector2 GetMouseRay()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
