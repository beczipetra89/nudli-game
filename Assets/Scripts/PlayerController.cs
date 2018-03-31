using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
   
    public float moveSpeed;
    //public bool facingRight;

    public float jumpHeight;
    private bool isGrounded;

    public AudioSource jumpSound;
    public AudioSource headJumpSound;
    public AudioSource raccoonSound;
    public AudioSource birdSound;
    //public int damage;


    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * moveSpeed * Time.deltaTime;

        if (moveSpeed != 0)
        {

        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Force);
            GetComponent<Animator>().SetBool("isJumping", true);
            StartCoroutine(JumpAnim());
            jumpSound.Play();
        }

        if (move.x > 0 && isGrounded)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            GetComponent<Animator>().SetBool("facingRight", true);
        }


        if (move.x < 0 && isGrounded)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
            GetComponent<Animator>().SetBool("facingRight", false);
        }

        /*
        //**********************************************************************************************
        	if(move.x < 0){
                GetComponent<Animator>().SetBool ("facingRight",false);
            }

            else if(move.x > 0){
                GetComponent<Animator>().SetBool ("facingRight",true);
            }

         //**********************************************************************************************
        */

        if (move.x == 0 || isGrounded == false && GetComponent<Animator>().GetBool("isJumping") == false)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
        }

        PlayerRaycast();



    }

    IEnumerator JumpAnim()
    {
        yield return new WaitForSeconds(0.333f);
        GetComponent<Animator>().SetBool("isJumping", false);
    }
    void OnTriggerEnter2D()
    {
        isGrounded = true;


    }
    void OnTriggerStay2D()
    {
        isGrounded = true;

    }
    void OnTriggerExit2D()
    {
        isGrounded = false;
    }


    /*
    //__________________________________________________________________________________ 
        // Hurth Player
    void OnTriggerEnter2D(Collider2D hit)
    {
        // Damage Player if SIDE collides with Enemy
        if (hit.CompareTag("BirdPoo"))
        {
            // hurthSound.Play();
            //Destroy(hit.gameObject);
            //SceneManager.LoadScene("Level1");
            hit.gameObject.GetComponent<PlayerHealth>().HurthPlayer(damage);

        }
    }
    */



    void onCollisionEnter2D(Collision2D col)
    {
      /*  if (col.gameObject.tag =="deadly")
        {
            SceneManager.LoadScene("Level1");
        } */

        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void PlayerRaycast(){


        // KILL ENEMIES ( HEAD JUMP and bounce off)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);


        //KILL CUCUMBER     
        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            headJumpSound.Play();

            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<EnemyScript>().enabled = false;
        }

        //KILL RACCOON
        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "Enemy2")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            raccoonSound.Play();
   
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<Enemy2Scripts>().enabled = false;
        }


        //KILL BIRD
        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "Enemy3")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            
           // Destroy(hit.collider.gameObject);

            hit.collider.gameObject.GetComponent<BirdEnemy>().Die();
           
            birdSound.Play();

            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            hit.collider.gameObject.GetComponent<BirdEnemy>().enabled = false;
        }


        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag != "Enemy") {
            isGrounded = true;
        }
        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag != "Enemy2")
        {
            isGrounded = true;
        }


    }

        } 
        
