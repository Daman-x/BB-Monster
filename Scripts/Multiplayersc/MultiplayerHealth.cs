
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MultiplayerHealth : NetworkBehaviour
{


    public float startingHealth = 1f;

    [SyncVar(hook = "OnChangeHealth")]
    public float currentHealth;



    private NetworkStartPosition[] spawnPoints;



    public Canvas canvas;
    public Image healthSlider;


    public Color damagedcolor = new Color(1f, 0f, 0f, 0.1f);
    public Color normalcolor = new Color(1f, 0f, 0f, 0.1f);

    public SkinnedMeshRenderer rend;

    Animator anim;
    public Animator anim2;
    AudioSource playerAudio;

    bool isDead;
    bool damaged;


    private void Start()
    {


        if (isLocalPlayer)
        {

            spawnPoints = FindObjectsOfType<NetworkStartPosition>();

        }


        playerAudio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();

    }

    void Update()
    {

        if (!isLocalPlayer)
            canvas.enabled = false;


        if (!damaged)
            rend.material.SetColor("_Color", normalcolor);


        damaged = false;

    }


    public void TakeDamage(float amount)
    {



        if (currentHealth < 0 && !isServer)
            return;


        damaged = true;

        currentHealth -= amount;


        playerAudio.Play();


        if (currentHealth <= 0 && !isDead)
        {

            RpcDeath();
            
           
        }
    }

  

    [ClientRpc]
    void RpcDeath()
    {

         isDead = true;
       
        
        if (isLocalPlayer)
         Cursor.lockState = CursorLockMode.None;

        anim.SetTrigger("Die");
        anim2.SetBool("state",true);

       
        playerAudio.Play();

        currentHealth = startingHealth;

        Invoke("RpcRespawn", 3);

    }


    void OnChangeHealth(float currentHealth)
    {

        healthSlider.fillAmount = currentHealth;
        rend.material.SetColor("_Color", damagedcolor);

    }

    
    [ClientRpc]
   void RpcRespawn()
    {
        if (isLocalPlayer)
        {

            Vector3 spawnPoint = Vector3.zero;

           
            if (spawnPoints != null && spawnPoints.Length > 0)
            {

                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;

            }


            if (!isServer)
                Cmdactive();
            else
                Rpcactive();


            anim.SetTrigger("Alive");
            anim2.SetBool("state", false);

            isDead = false;

            transform.position = spawnPoint;

        }

    }

    public void Deadback()
    {

        SceneManager.LoadScene("Menu Scene");

    }

  
    [Command]
    void Cmdactive()
    {
        anim.SetTrigger("Alive");
       
    }

    [ClientRpc]
    void Rpcactive()
    {
        anim.SetTrigger("Alive");
    }

}
