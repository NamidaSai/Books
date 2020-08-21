using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CryptoBook : MonoBehaviour, IRaycastable
{
    [SerializeField] GameObject cryptoCanvas = null;
    [SerializeField] List<TMP_InputField> fields = null;
    [SerializeField] string solution = null;


    private void Start() 
    {
        DisableUI();
    }
    public void TriggerInteractionEvent()
    {
        cryptoCanvas.SetActive(true);
    }

    public void DisableUI()
    {
        cryptoCanvas.SetActive(false);
    }

    public void CheckIfDecoded()
    {
        if (solution == null)
        {
            Debug.LogWarning("Solution has not been set.");
        }

        List<string> solutionCheck = new List<string>();

        foreach (TMP_InputField field in fields)
        {
            solutionCheck.Add(field.text);
        }

        if (string.Compare(solution, string.Join("", solutionCheck), true) == 0)
        {
            TriggerDecodedEvent();
        }
    }

    private void TriggerDecodedEvent()
    {
        Debug.Log("Crypto Book has been solved.");
        cryptoCanvas.SetActive(false);
    }
}
