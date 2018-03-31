using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BIRD ENEMY FOLLOWS PLAYER (SUICIDAL BEHAVIOUR)

public class BirdEnemy : MonoBehaviour {

    public GameObject target;
    public float ratio = 0.5f;
    bool inRange;
    public float range;
    public GameObject explosion;

    public AudioSource hurthSound;
    public int damage;


    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }
    
    void Update()
    {
        // birdSound.Play();
        if (!inRange)
        {
            // Defining a range radius
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);
            foreach (Collider2D h in hits)
                if (h.gameObject == target)
                { //check not to care anyone else in range than the Player
                    inRange = true;
                    break;
                }
        }

        if (inRange)
        {
            //  birdSound.Play();
            float step;

            if (Vector3.Dot(target.transform.position - transform.position, target.transform.localScale.x * Vector3.right) > 0)
            {
                step = ratio * 2;
            } else {
                step = ratio;
            }
            // Bir movement, always follows where Player walks
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }

 
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Projectile") || other.CompareTag("Player")) {
             other.gameObject.GetComponent<PlayerHealth>().HurthPlayer(damage);
             hurthSound.Play();
              Die();
            }
         }
   

    // Kill bird by explosion
    public void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
         // birdSound.Play();
        Destroy(this.gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    /*
   // Hurth Player
    void OnTriggerEnter2D(Collider2D hit)
    {
        // Damage Player if collides with Enemy
        if (hit.CompareTag("Player"))
        {
           // hurthSound.Play();
            hit.gameObject.GetComponent<PlayerHealth>().HurthPlayer(damage);

        }
    }
   */
}
