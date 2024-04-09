using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private Animator animator;
    private bool isMenuOpen;
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMenu();
        }
    }

    public void OpenMenu()
    {
        SwitchMenuAnimation();
    }

    public void CloseMenu()
    {
        animator.SetBool(IsOpen, false);
        isMenuOpen = false;
    }

    public void SwitchMenuAnimation()
    {
        if (animator == null)
            return;

        animator.SetBool(IsOpen, !isMenuOpen);
        isMenuOpen = !isMenuOpen;
    }
}