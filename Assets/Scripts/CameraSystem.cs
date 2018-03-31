using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {
	public GameObject objectToFollow; 

	public float speed =2.0f;

	void Update(){
	
		float interpolation = speed * Time.deltaTime;

		Vector3 position = this.transform.position;
		position.y = Mathf.Lerp (transform.position.y , objectToFollow.transform.position.y + 2.0f, interpolation);
		position.x = Mathf.Lerp (transform.position.x, objectToFollow.transform.position.x, interpolation);
        transform.position = position;
	}

}