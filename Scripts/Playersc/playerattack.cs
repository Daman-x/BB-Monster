using UnityEngine;


public class playerattack : MonoBehaviour
{
    public int damageamount;
    public float timing = 2f;
    public float range = 13f;
    float timer;
    Ray shootRay = new Ray();

    RaycastHit shootHit;

    int shootableMask;

    PlayerMove playermove;
    GameObject player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shootableMask = LayerMask.GetMask("kill");
        playermove = player.GetComponent<PlayerMove>();
        }



    void Update()
    {
        timer += Time.deltaTime; 

        if (playermove.a == true && timer >= timing )

        {
            timer = 0f;
            attack();
        }
    }






    void attack()

    {
        shootRay.origin = transform.position;

        shootRay.direction = transform.forward;


        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))

        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)

            {

                 enemyHealth.TakeDamage(damageamount);

            }



        }
        
    }
}
