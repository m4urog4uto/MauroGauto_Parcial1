using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void FadeOut()
    {
        animator.SetBool("isFadeOut", true);
    }
}
