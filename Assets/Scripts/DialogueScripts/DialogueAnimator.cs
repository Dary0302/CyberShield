using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public DialogueManager dm;

    public void OnTriggerEnter2D(Collider2D other)
    {
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        dm.EndDialogue();
    }
}
