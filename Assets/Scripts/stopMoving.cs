using UnityEngine;

public class DisableScrollOnCollision : MonoBehaviour
{
    private HorizontalDrag scrollScript;

    void Start()
    {
        // Получаем компонент Scroll на этом объекте
        scrollScript = GetComponent<HorizontalDrag>();

        // Проверяем, есть ли компонент Scroll
        if (scrollScript == null)
        {
            Debug.LogError("Scroll не найден на этом объекте!");
        }
    }

    // Вызывается, когда происходит столкновение с другим коллайдером
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, является ли объект, с которым столкнулся данный объект, объектом области
        if (collision.gameObject.CompareTag("Area"))
        {
            // Выключаем скрипт Scroll
            if (scrollScript != null)
            {
                scrollScript.enabled = false;
            }
        }
    }

    // Вызывается, когда объект перестает сталкиваться с другим коллайдером
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Проверяем, является ли объект, с которым перестал сталкиваться данный объект, объектом области
        if (collision.gameObject.CompareTag("Area"))
        {
            // Включаем скрипт Scroll
            if (scrollScript != null)
            {
                scrollScript.enabled = true;
            }
        }
    }
}
