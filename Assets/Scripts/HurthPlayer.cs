using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurthPlayer : MonoBehaviour
{

    public AudioSource hurthSound;
    public int damage;
   


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        // Damage Player if SIDE collides with Enemy
        if (hit.CompareTag("Player"))
        {
            hurthSound.Play();
            //Destroy(hit.gameObject);
            //SceneManager.LoadScene("Level1");
            hit.gameObject.GetComponent<PlayerHealth>().HurthPlayer(damage);

        }
    }
}
