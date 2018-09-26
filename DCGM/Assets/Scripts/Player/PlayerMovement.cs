using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour {

    ThirdPersonCharacter thirdPersonCharacter;
    public CameraRayCaster cameraRay;
	private bool IsDirectMove=false;
    public float minMoveStopDistance=1;
    public float minAttackStopDistance = 5;

    Vector3 targetPosition,clickPoint;
	void Start () {
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        targetPosition = transform.position;
        
        

    


    }

    // Update is called once per frame
    private void LateUpdate()
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


            clickPoint = cameraRay.Hit.point;


                switch (cameraRay.CurrentLayerHited)
				{

				case GameConstants.Layers.Walkable:
					
					targetPosition = ShortDestination(clickPoint, minMoveStopDistance);
					break;

				case GameConstants.Layers.Enemy:
                    targetPosition = ShortDestination(clickPoint, minAttackStopDistance);
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
    private Vector3 ShortDestination(Vector3 destination,float shortening)
    {
        /*Con este metodo podemos generar un vector unitario que aputara a la dirección de destino el cual podremos
         multiplicar por un factor. Luego lo restaremos al vector de destino y tendremos un vector reducido por el valor de shortening*/
        Vector3 originalDestination = destination - transform.position;
        Vector3 reducedDestination= originalDestination.normalized * shortening;
        Vector3 shortedDestination = destination - reducedDestination;

        return shortedDestination;


    }
    private void OnDrawGizmos()
    {
        if(Gizmos.color != Color.black)
            Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, targetPosition);
        Gizmos.DrawSphere(targetPosition, 0.1f);
        Gizmos.DrawLine(transform.position, clickPoint);
        Gizmos.DrawSphere(clickPoint, 0.15f);
    }

    void FixedUpdate () {
		Vector3 target;
		if (IsDirectMove)
			target = targetPosition;
		else
			target = targetPosition - transform.position;
        
        if (target.sqrMagnitude > 0)
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
