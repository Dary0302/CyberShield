using LevelsLogic._1lvl;
using UnityEngine;

public class HorizontalDrag : MonoBehaviour
{
    private bool isDragging = false;
    private bool canDrag = true; // ���� ��� ����������/���������� ��������������
    private float offsetX;

    // ������ �� �������� ������ ��� ��������� �����������
    public GameObject childObject;

    // ������ ��� ��������� ������� ��� ������������ � ��������
    public Sprite collisionSprite;

    // ������ �� ������ � ����������� �������
    public GameObject timerObject;

    void OnMouseDown()
    {
        if (!canDrag)
            return;

        // ��� ����� �� ������ ��������� ��������� ��������
        offsetX = transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (!isDragging || !canDrag)
            return;

        // �������� ������� ������� ���� � ������� �����������
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ������������� ������� �������, �������� ��������� �������� � ����������� ����������� �� �����������
        transform.position = new Vector3(mousePos.x + offsetX, transform.position.y, transform.position.z);
    }

    void OnMouseUp()
    {
        // ��� ���������� ���� ��������� ��������������
        isDragging = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ��������� ��������������, ����� ������ �������� ������������ � ��������
        if (other.CompareTag("Area"))
        {
            canDrag = false;

            SpriteRenderer childSpriteRenderer = childObject.GetComponent<SpriteRenderer>();
            childSpriteRenderer.sprite = collisionSprite;

            // ���� ���� ������ �� ������ � ��������, �������� ����� StartTimer() �� ��� ���������� Timer
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
        // ��������� ��������������, ����� ������ ��������� ������������ � ��������
        if (other.CompareTag("Area"))
        {
            canDrag = true;
        }
    }
}
