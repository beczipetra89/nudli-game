using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooter : MonoBehaviour {
    public GameObject projectile;
    public float speedFactor;
    public float delay;


	public GameObject target;
	public float ratio = 0.5f;
	bool inRange;
	public float range;


   public AudioSource poopSound;
    //public int damage;

    // Use this for initialization
    void Start () {
      StartCoroutine(Shoots());

		{
			if (target == null)
			{
				target = GameObject.FindGameObjectWithTag("Player");

			}
		}



	
	}
	
	// Update is called once per frame
	void Update () {

		if (!inRange)
		{
			// Defining a range radius
			Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);
			foreach (Collider2D h in hits)
				if (h.gameObject == target)
				{ //check not to care anyone else in range than the Player
					inRange = true;
					poopSound.Play();
					break;
				}
		}


	}


   

    IEnumerator Shoots()
    {
        while (true)
        {
            //Not to shoot continuously
            yield return new WaitForSeconds(delay);

            GameObject clone = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);

            //shooting speed
            clone.GetComponent<Rigidbody2D>().velocity = transform.right * speedFactor;
			//poopSound.Play();
        }
    }



	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}


