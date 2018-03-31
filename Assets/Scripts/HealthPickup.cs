using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    public PlayerHealth playerHealth;

    public int healthBonus;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //col.gameObject.GetComponent<PlayerHealth>().playerCurrentHealth <playerHealth.playerMaxHealth;
        //if (col.gameObject.GetComponent<PlayerHealth>().playerCurrentHealth < playerHealth.playerMaxHealth) {
            Destroy(gameObject);
            col.gameObject.GetComponent<PlayerHealth>().HealPlayer(healthBonus);
            // playerHealth.playerCurrentHealth = playerHealth.playerCurrentHealth + healthBonus;

        //}
    }
//
}
