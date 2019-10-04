using UnityEngine;

public class Entry : MonoBehaviour {

    

    public Animator anim;

	void Update ()
    {
        

        if (Input.anyKey)
        {
            anim.SetTrigger("Starter");
        }
		
	}
}
