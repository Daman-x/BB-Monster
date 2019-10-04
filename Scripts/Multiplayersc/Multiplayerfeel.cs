using UnityEngine.Networking;
using UnityEngine;
public class Multiplayerfeel : NetworkBehaviour {

    [SerializeField] float power;
    [SerializeField] GameObject gb;
    [SerializeField] Transform tf;
    public float timer =2f;
    private float timing;

    MultiplayerHealth health;


    public override void OnStartLocalPlayer()
    {
        health = GetComponent<MultiplayerHealth>();
    }


    void Update()
    {

        if (!isLocalPlayer || health.currentHealth <= 0)
            return;


        timing += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timing >= timer)
        {
            CmdSpawn();
            timing = 0f;
        }
        
    }

    [Command]
    void CmdSpawn()
    {
        GameObject g = Instantiate(gb, tf.position, tf.rotation) as GameObject;
        g.GetComponent<Rigidbody>().AddForce(tf.forward * power);

        NetworkServer.Spawn(g);
    }
}
