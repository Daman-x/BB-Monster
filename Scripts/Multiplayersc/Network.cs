
using UnityEngine;
using UnityEngine.Networking;
public class Network : NetworkManager
{
    [Header("Scene Camera PRO")]
    [SerializeField] Transform Scene;
    [SerializeField] float cameraradius = 24f;
    [SerializeField] float cameraspeed = 3f;
    [SerializeField] bool canrotate = true;
    [SerializeField] GameObject g;
    [SerializeField] GameObject back;
    float rotation;



    public override void OnStartClient(NetworkClient Client)
    {
        canrotate = false;


    }
    public override void OnStartHost()
    {
        canrotate = false;


    }
    public override void OnStopClient()
    {
        canrotate = true;

    }
    public override void OnStopHost()
    {
        canrotate = true;
    }

    void Update()
    {
        if (!canrotate)
        {
            back.active = false;
            return;
        }

        back.active = true;
        rotation += cameraspeed * Time.deltaTime;
        if (rotation >= 360f)
            rotation -= 360f;

        Scene.position = g.transform.position;
        Scene.rotation = Quaternion.Euler(0f, rotation, 0f);
        Scene.Translate(0f, cameraradius, -cameraspeed);
        Scene.LookAt(Vector3.zero);

    }


}
