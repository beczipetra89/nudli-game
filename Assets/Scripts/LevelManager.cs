using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public AudioSource dieSound;
    public GameObject currentCheckPoint;

    private PlayerController player;
   

    void Start () {
        player = FindObjectOfType<PlayerController>();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RespawnPlayer()
    {
        Debug.Log("Player Respawn");
        player.transform.position = currentCheckPoint.transform.position;
        dieSound.Play();
    }
}
