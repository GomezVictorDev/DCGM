using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // Use this for initialization
    Transform playerTransform;
    Transform cameraTransform;


	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        Vector3 target = new Vector3(playerTransform.position.x , playerTransform.position.y + 10, playerTransform.position.z - 10);
        cameraTransform.position = target;
		
	}
}
