using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// RACCOON ENEMY MOVEMENT

public class Enemy2Scripts : MonoBehaviour {

    public LayerMask enemyMask;
    public float speed = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;


    public AudioSource hurthSound;
    public int damage;


    // Use this for initialization
    void Start () {

        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //Check if there is ground in front of the enemy2 before move forwad
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
       // Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
      //  Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() *.02f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * .02f, enemyMask);



        //Turn around (rotate sprite) if there is no ground or wall blocks
        if (!isGrounded || isBlocked)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }


        //Always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;


        // Clear up unkilled enemies
        if (gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    // Hurth Player
    void OnTriggerEnter2D(Collider2D hit)
    {
        // Damage Player if SIDE collides with Enemy
        if (hit.CompareTag("Player"))
        {
           hurthSound.Play();
            hit.gameObject.GetComponent<PlayerHealth>().HurthPlayer(damage);
        }
    }
}
