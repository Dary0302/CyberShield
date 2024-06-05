using LevelsLogic._1lvl;
using UnityEngine;

public class HorizontalDrag : MonoBehaviour
{
    private bool isDragging = false;
    private bool canDrag = true;
    private float offsetX;

    public GameObject childObject;
    public Sprite collisionSprite;
    public GameObject timerObject;

    private Vector3 initialPosition;

    void OnMouseDown()
    {
        if (!canDrag)
            return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offsetX = transform.position.x - mousePos.x;
        isDragging = true;
    }

    void FixedUpdate()
    {
        if (!isDragging || !canDrag)
            return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x + offsetX, transform.position.y, transform.position.z);
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Area"))
        {
            canDrag = false;

            // Остановка объекта и фиксация его позиции
            initialPosition = transform.position;
            transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);

            SpriteRenderer childSpriteRenderer = childObject.GetComponent<SpriteRenderer>();
            childSpriteRenderer.sprite = collisionSprite;

            if (timerObject != null)
            {
                SecondTimer timerComponent = timerObject.GetComponent<SecondTimer>();
                if (timerComponent != null)
                {
                    timerComponent.StartTimer();
                }
                else
                {
                    Debug.LogError("Timer component not found on the specified GameObject!");
                }
            }
            else
            {
                Debug.LogError("Timer object reference is null!");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Area"))
        {
            canDrag = true;
        }
    }
}
