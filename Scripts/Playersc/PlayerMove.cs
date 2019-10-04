using UnityEngine;
public class PlayerMove : MonoBehaviour {

    public bool a;
    public float speed = 10f;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void FixedUpdate ()
    {
       
        float h = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float v = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
         a = Input.GetKeyDown("x");
        Animating(h, v);
        transform.Translate(h, 0, v);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

        if (a==true)
            anim.SetBool("Attack", true);
        if (a == false)
            anim.SetBool("Attack", false);
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }


}
