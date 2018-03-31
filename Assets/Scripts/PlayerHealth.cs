using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour {
    public AudioSource dieSound;

    public int playerMaxHealth;
    public static int playerCurrentHealth;
    
    public Slider healthBar;

    /* [System.Serializable]
     public class PlayerStats {
        public int Health = 100;
     }



     public PlayerStats playerStats = new PlayerStats();
    // public int fallBoundary = -20;


         */

    void Start() {

        healthBar = GetComponent<Slider>();
        playerCurrentHealth = playerMaxHealth;

      
    }

    void Update () {

        /*
        // PLAYER FALLS DOWN DIES
        if (transform.position.y <= -10)
        {
            dieSound.Play();
            Destroy(gameObject);
            SceneManager.LoadScene("Level1");
        }

        */

        // No life left, Player dies
        if (playerCurrentHealth <=0) {
            dieSound.Play();
            playerCurrentHealth = 0;
            Destroy(gameObject);

            SceneManager.LoadScene("Level1");
        }

        // Give damage value so high that will instantly kill the player 
        //DamagePlayer(999999999);
       
        healthBar.value = PlayerHealth.playerCurrentHealth;


    }

    /*
    // DAMAGE METHOD
    public void DamagePlayer(int damage) {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0){
            EnemyScript.KillPlayer(this);
          //  EnemyScript.OnTriggerEnter2D(this);
            SceneManager.LoadScene("Level1");
        }
    }
     */

    // heal player by specific number
   public void HealPlayer(int healthBonus) {
        playerCurrentHealth += healthBonus;
        if (playerCurrentHealth >= playerMaxHealth) {
            playerCurrentHealth = playerMaxHealth;
        }
    }

    public void HurthPlayer(int damage) {
        playerCurrentHealth -= damage;
    }


    public void SetMaxHealth() {
        playerCurrentHealth = playerMaxHealth;
    }
}
      
   

