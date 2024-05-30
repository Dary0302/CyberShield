using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    private int countHealthPoints = 1;

    void Start()
    {
        //todo: В старте добавляем сердечки в поле
    }

    void Update()
    {
        //todo: В апдейте обновляем количество сердечек
    }

    public void WrongAnswer()
    {
        countHealthPoints--;
        Debug.Log("Aghhh");
    }
}
