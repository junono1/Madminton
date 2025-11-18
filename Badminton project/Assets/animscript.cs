using System;
using UnityEngine;

public class animscript : MonoBehaviour
{
    public SwingerAction swinger;
    Animator anim;
    void OnEnable()
    {
        anim = GetComponent<Animator>();
        swinger.OndirectionSelected += DoAction;
    }

    void DoAction(int direction)
    {
        if (direction == 1)
        {
            anim.SetTrigger("stand");
        }
        if (direction == 2)
        {
            anim.SetTrigger("ready");
        }
        if (direction == 3)
        {
            anim.SetTrigger("swing");
        }
    }
}
