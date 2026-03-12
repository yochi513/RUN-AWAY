using UnityEngine;

//ö†èd
public class doormove : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        anim.SetBool("Door Bool", true);
    }

    public void StopAnimation()
    {
        anim.SetBool("Door Bool", false);
    }
}

