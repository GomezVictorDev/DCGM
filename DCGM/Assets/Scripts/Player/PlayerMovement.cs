using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour {

    ThirdPersonCharacter thirdPersonCharacter;
    public CameraRayCaster cameraRay;
    
    Vector3 targetPosition;
	void Start () {
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        targetPosition = transform.position;


    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cameraRay.IsHited)
            {


                switch (cameraRay.LayerHited)
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



       

    }
    void FixedUpdate () {

        Vector3 target = targetPosition - transform.position;
        
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
