using UnityEngine;

public class HorizontalDrag : MonoBehaviour
{
    private bool isDragging = false;
    private bool canDrag = true; // Флаг для разрешения/запрещения перетаскивания
    private float offsetX;

    // Ссылка на дочерний объект для изменения изображения
    public GameObject childObject;

    // Спрайт для дочернего объекта при столкновении с областью
    public Sprite collisionSprite;

    void OnMouseDown()
    {
        if (!canDrag)
            return;

        // При клике на объект сохраняем начальное смещение
        offsetX = transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (!isDragging || !canDrag)
            return;

        // Получаем текущую позицию мыши в мировых координатах
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Устанавливаем позицию объекта, сохраняя начальное смещение и ограничивая перемещение по горизонтали
        transform.position = new Vector3(mousePos.x + offsetX, transform.position.y, transform.position.z);
    }

    void OnMouseUp()
    {
        // При отпускании мыши завершаем перетаскивание
        isDragging = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Запрещаем перетаскивание, когда объект начинает сталкиваться с областью
        if (other.CompareTag("Area"))
        {
            canDrag = false;

            SpriteRenderer childSpriteRenderer = childObject.GetComponent<SpriteRenderer>();
            childSpriteRenderer.sprite = collisionSprite;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Разрешаем перетаскивание, когда объект перестает сталкиваться с областью
        if (other.CompareTag("Area"))
        {
            canDrag = true;
        }
    }
}
