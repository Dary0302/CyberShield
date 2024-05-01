using UnityEngine;

public class HorizontalDrag : MonoBehaviour
{
    private bool isDragging = false;
    private float offsetX;

    void OnMouseDown()
    {
        // При клике на объект сохраняем начальное смещение
        offsetX = transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (!isDragging)
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
}
