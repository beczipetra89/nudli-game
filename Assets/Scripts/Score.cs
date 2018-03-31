using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Score : MonoBehaviour {

    public AudioSource catchSound;

    private float timeLeft = 120;
	//public int playerScore = 0;
	public GameObject timeLeftUI;
	//public GameObject highScoreUI;

	public Text fishText;
	private int fishes= 0;
	//private int highScore=0;

	string fishMessage;

	void Update(){
		// Timer count down
		timeLeft -= Time.deltaTime;
		timeLeftUI.gameObject.GetComponent<Text>().text = (" "+(int)timeLeft);



		// Game over, restart
		if (timeLeft < 0.1f) {
			SceneManager.LoadScene ("Level1");
		}

	}

	// Use this for initialization
	void Start () {

	}


	void OnTriggerEnter2D (Collider2D hit)
	{

		if (hit.CompareTag ("Fish")) {
            catchSound.Play();
            fishes += 1;
			fishMessage = " " + fishes; 
			fishText.text = fishMessage;

			Destroy (hit.gameObject);
		}

        
		if (hit.CompareTag ("End")) {
			SceneManager.LoadScene ("Level2");
			//highScore = fishes /2;
			//fishMessage = " " + highScore+(int)(timeLeft * 10);
			//fishText.text = fishMessage;	
		} 
       




    }
}
