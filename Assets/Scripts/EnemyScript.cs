using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{


    public int EnemySpeed;
    public int XMoveDirection;
    



    // Update is called once per frame
    void Update()
    {

        //MOVEMENTS
        // Enemy movement (left and right walk between 2 objects)

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (hit.distance < 0.3f)
        {
            Flip();
        }

       
        // Clear up unkilled enemies
        if (gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }


    }



    /*
    void OnTriggerEnter2D(Collider2D hit)
    {
        // Enemy collides with Player, kills player instatly ****************************************************************************
        if (hit.CompareTag("Player"))
        {
            Destroy(hit.gameObject);
            SceneManager.LoadScene("Level1");
        }

    }  */

        void Flip()
        {
            if (XMoveDirection > 0)
            {
                XMoveDirection = -1;
            }
            else
            {
                XMoveDirection = 1;
            }
        }
    }
