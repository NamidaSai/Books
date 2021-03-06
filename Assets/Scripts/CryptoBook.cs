﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CryptoBook : MonoBehaviour
{
    [SerializeField] GameObject cryptoCanvas = null;
    [SerializeField] List<TMP_InputField> fields = null;
    [SerializeField] string solution = null;
    [SerializeField] Sprite solvedSprite = null;


    private void Start() 
    {
        DisableUI();
    }

    public void TriggerCryptoEvent()
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

        if (FindObjectOfType<LevelController>().GetCodeIsDecrypted()) { return; }

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
        GetComponent<SpriteRenderer>().sprite = solvedSprite;
        cryptoCanvas.SetActive(false);
        FindObjectOfType<LevelController>().SetCodeIsDecrypted(true);
    }
}
