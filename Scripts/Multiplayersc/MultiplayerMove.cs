
using UnityEngine;
using UnityEngine.Networking;
public class MultiplayerMove : NetworkBehaviour
{
    Transform maincamera;

    public float camerad = 1.5f;
    public float camerah = 2f;

    MultiplayerHealth health;
    public GameObject view;
    Animator anim;

    public float speed = 3f;


    public override void OnStartLocalPlayer()
    {
        anim = GetComponent<Animator>();
        maincamera = Camera.main.transform;
        cameramove();
        health = GetComponent<MultiplayerHealth>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void FixedUpdate()
    {


        if (!isLocalPlayer || health.currentHealth <= 0)
            return;


        float ws = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float ad = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        float mx = Input.GetAxisRaw("Mouse X");

        Vector3 lookhere = new Vector3(0, mx, 0);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

        transform.Translate(ws, 0, ad);
        transform.Rotate(lookhere);
        Animating(ws, ad);
        cameramove();
        
        

        if (Input.GetMouseButtonDown(0))
            anim.SetBool("Attack", true);

        if(!Input.GetMouseButtonDown(0))
            anim.SetBool("Attack", false);
        

    }

    

    private void cameramove()
    {
        maincamera.position = view.transform.position;
        maincamera.rotation = view.transform.rotation;
       
    }


    void Animating(float ws, float ad)
    {
        bool walking = ws != 0f || ad != 0f;
        anim.SetBool("IsWalking", walking);
    }

   
    
}
