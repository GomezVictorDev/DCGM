using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour {

    ThirdPersonCharacter thirdPersonCharacter;
    public CameraRayCaster cameraRay;
	private bool IsDirectMove=false;
    
    Vector3 targetPosition;
	void Start () {
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        targetPosition = transform.position;
        
        

    


    }

    // Update is called once per frame
    private void Update()
    {
        
		if (Input.GetKey (KeyCode.G)) {
		
			IsDirectMove = !IsDirectMove;
			targetPosition = transform.position;

		}

		if (IsDirectMove) {
			
			FindTargetPositionOnJoystick ();
		}
			
		else
			FindTargetPositionOnClick ();


       

    }
	private void FindTargetPositionOnClick(){
		
		if (Input.GetMouseButtonDown(0))
		{
		//	if (cameraRay.IsHited)




				switch (cameraRay.CurrentLayerHited)
				{
				case GameConstants.Layers.Walkable:
					RaycastHit hit = cameraRay.Hit;
					targetPosition = hit.point;
					break;

				case GameConstants.Layers.Enemy:
					targetPosition = transform.position;
					break;

				}
			



		}
	}

	private void FindTargetPositionOnJoystick(){
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 camFoward = Vector3.Scale (Camera.main.transform.forward, new Vector3 (1, 0, 1)).normalized;
		targetPosition = v * camFoward + Camera.main.transform.right * h;
		
	}

    void FixedUpdate () {
		Vector3 target;
		if (IsDirectMove)
			target = targetPosition;
		else
			target = targetPosition - transform.position;
        
        if (target.sqrMagnitude > 0.3f)
        {
            thirdPersonCharacter.Move(target, false, false);

        }
        else
        {
            if (target != Vector3.zero)
            {
                target = Vector3.zero;
                thirdPersonCharacter.Move(target, false, false);

            }
                
        }
        

	}



}
