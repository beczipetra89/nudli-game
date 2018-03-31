using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPooDamage : MonoBehaviour {
 //  public AudioSource hurthSound;
    public int damage;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Hurth Player
    void OnTriggerEnter2D(Collider2D hit)
    {
        // Damage Player if SIDE collides with Enemy
        if (hit.CompareTag("Player"))
        {
          //hurthSound.Play();
            //Destroy(hit.gameObject);
            //SceneManager.LoadScene("Level1");
            hit.gameObject.GetComponent<PlayerHealth>().HurthPlayer(damage);

        }
    }

}
