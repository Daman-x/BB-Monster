
using UnityEngine;
using UnityEngine.Networking;

public class MultiplayerAttack : NetworkBehaviour
{

    [SerializeField] float Attacklife = 1f;
    float age;
    


    
    [ServerCallback]
     void Update()
    {
        age += Time.deltaTime;

        if(age > Attacklife)
        {
          NetworkServer.Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider other)
    {


        if (!isServer)
            return;


        if (other.gameObject.tag != "Player")
        {
            Destroy(gameObject);
            return;
        }

        MultiplayerHealth h = other.gameObject.GetComponent<MultiplayerHealth>();

        if (h != null)
            h.TakeDamage(0.15f);

    }

	
}
