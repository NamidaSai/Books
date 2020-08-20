using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float distanceToInteract = 1f;
    [SerializeField] float moveSpeed = 10f;

    Vector2 targetPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleInteract();
        }

        HandleMovement();
    }

    private void HandleInteract()
    {
        RaycastHit2D hit = Physics2D.Raycast(GetMouseRay(), Vector2.zero);

        if (hit.collider == null) { return; }

        GameObject targetObject = hit.transform.gameObject;

        InteractWithObject(targetObject);
    }

    private void HandleMovement()
    {
        if (Vector2.Distance(transform.position, targetPosition) >= distanceToInteract)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
        }
    }

    private void InteractWithObject(GameObject targetObject) 
    {
        IRaycastable raycastable = targetObject.GetComponent<IRaycastable>();
        if (raycastable == null)
        {
           Debug.LogWarning("Interactable Object is missing IRaycastable component.");
           return;
        }

        targetPosition = targetObject.transform.position;
        raycastable.OnClickEvent();
    }
    
    private static Vector2 GetMouseRay()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
