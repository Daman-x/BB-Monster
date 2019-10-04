using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    CapsuleCollider capsuleCollider;
    ZombieNAV zombienav;
    PlayerHealth player;
    bool isDead;
    GameObject player1;


    void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        player = player1.GetComponent<PlayerHealth>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        zombienav = GetComponent<ZombieNAV>();

        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
            return;

        enemyAudio.Play();

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        player.Health();
        anim.SetTrigger("die");

        enemyAudio.clip = deathClip;
        enemyAudio.Play();
         StartSinking();
    }


    public void StartSinking()
    {
        ScoreManager.score += scoreValue;
         zombienav.enabled = false;
        Destroy(gameObject, 10f);
    }
}
