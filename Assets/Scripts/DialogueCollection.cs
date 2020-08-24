using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Collection", menuName = "Books/DialogueCollection", order = 0)]
public class DialogueCollection : ScriptableObject 
{
    [SerializeField] List<VocalPrompt> vocalPrompts = new List<VocalPrompt>();
    
    public string GetVocalPromptText(string id)
    {
        return vocalPrompts.Find(x => x.GetID() == id).promptText;
    }

    public AudioClip GetVocalPromptAudio(string id)
    {
        return vocalPrompts.Find(x => x.GetID() == id).promptAudio;
    }

}

[System.Serializable]
class VocalPrompt 
{
    public string promptID = "id";
    [TextArea(2,2)] public string promptText = null;
    public AudioClip promptAudio = null;

    public string GetID()
    {
        return promptID;
    }
}