using UnityEngine;
using UnityEngine.UI;

public class ButtonClickBlocker : MonoBehaviour
{
    // Ссылки на кнопки, которые нужно заблокировать
    public Button[] buttonsToBlock;

    private void Awake()
    {
        // Проверяем, что кнопки заданы
        if (buttonsToBlock == null || buttonsToBlock.Length == 0)
        {
            Debug.LogError("Buttons to block are not assigned!");
        }
    }

    private void OnEnable()
    {
        // Блокируем кнопки при включении объекта
        BlockButtons();
    }

    private void OnDisable()
    {
        // Разблокируем кнопки при выключении объекта
        UnblockButtons();
    }

    private void BlockButtons()
    {
        // Блокируем нажатия на все кнопки
        foreach (var button in buttonsToBlock)
        {
            button.interactable = false;
        }
    }

    private void UnblockButtons()
    {
        // Разблокируем нажатия на все кнопки
        foreach (var button in buttonsToBlock)
        {
            button.interactable = true;
        }
    }
}
