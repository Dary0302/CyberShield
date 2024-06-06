using DialogueScripts;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public DialogueManager dm;
    
    public void OnTriggerExit2D(Collider2D other)
    {
        dm.EndDialogue();
    }
}
