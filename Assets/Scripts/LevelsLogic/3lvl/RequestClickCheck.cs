using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RequestClickCheck : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector] public UnityEvent<string, string> LinkedWordClicked;
    private TMP_Text request;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        var mousePosition = new Vector3(eventData.position.x, eventData.position.y, 0);
        var linkTaggedText = TMP_TextUtilities.FindIntersectingLink(request, mousePosition, null);

        if (linkTaggedText != -1)
        {
            var linkInfo = request.textInfo.linkInfo[linkTaggedText];
            Debug.Log(linkInfo.linkTextfirstCharacterIndex);
            LinkedWordClicked?.Invoke(linkInfo.GetLinkID(), linkInfo.GetLinkText());
        }
    }

    public void Initialize(TMP_Text request)
    {
        this.request = request;
    }
}
