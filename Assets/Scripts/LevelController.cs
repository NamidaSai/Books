using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    bool codeIsDecrypted = false;

    public bool GetCodeIsDecrypted()
    {
        return codeIsDecrypted;
    }

    public void SetCodeIsDecrypted(bool isDecrypted)
    {
        codeIsDecrypted = isDecrypted;
    }
}
