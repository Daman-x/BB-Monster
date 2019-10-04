using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerHealth StoneHealth;
    public PlayerHealth DragonHealth;
    public PlayerHealth TronHealth;
    public PlayerHealth BeastHealth;

    public float backin = 5f;

    Animator anim;
    float backmenu;



    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0 && StoneHealth.currentHealth <= 0 && DragonHealth.currentHealth <= 0 && TronHealth.currentHealth <= 0 && BeastHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            backmenu += Time.deltaTime;

            if (backmenu >= backin)
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Menu Scene");
            }
        }
       

       
    }
}
