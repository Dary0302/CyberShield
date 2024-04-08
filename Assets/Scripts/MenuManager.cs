using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Animator animator;
    private Animation animation;

    void Start()
    {
        animator = GetComponent<Animator>();
        animation = GetComponent<Animation>();
    }

    public void PlayMenuAnimation()
    {
        bool a = animator.GetBool("IsOpen");

        if (animator != null)
        {
            if (a)
            {
                animator.SetBool("IsOpen", false);
            }
            else
            {
                animator.SetBool("IsOpen", true);
            }
        }
    }

    public void PlayAmimation()
    {
        if (animation != null)
        {
            animation.Play();
        }
    }
}
