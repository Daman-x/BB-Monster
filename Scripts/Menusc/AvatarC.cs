using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarC : MonoBehaviour
{ 
    public Animator anim;



    public void avatar()
    {
        anim.SetBool("selection", true);  

    }

    public void backa()
    {
        anim.SetBool("selection", false);
    }
}
