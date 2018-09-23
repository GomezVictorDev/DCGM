using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAfforance : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    Texture2D walkCursor;
    [SerializeField]
    Texture2D enemyCursor;
    [SerializeField]
    Texture2D unknowCursor;

    [SerializeField]
    CameraRayCaster cameraRayCaster;
	[SerializeField] [Range(0,1)]
	float relativeCursorOffsetX;
	[SerializeField] [Range(0,1)]
	float relativeCursorOffsetY;



    void Start () {
		relativeCursorOffsetX *= enemyCursor.width;
		relativeCursorOffsetY *= enemyCursor.height;
		cameraRayCaster.onLayerHitedEvent+=OnLayerHited;
		cameraRayCaster.onLayerNotHitedEvent +=OnLayerNotHited;
		
	}
	private void OnLayerHited(GameConstants.Layers layer){
	


		switch(layer)
		{

		case GameConstants.Layers.Enemy:
			Vector2 hotspotEnemy = new Vector2(enemyCursor.width * relativeCursorOffsetX, enemyCursor.height * relativeCursorOffsetY);
			Cursor.SetCursor(enemyCursor, hotspotEnemy, CursorMode.Auto);
			break;
		case GameConstants.Layers.Walkable:
			Vector2 hotspotWalk = new Vector2(walkCursor.width * relativeCursorOffsetX, walkCursor.height * relativeCursorOffsetY);
			Cursor.SetCursor(walkCursor, hotspotWalk, CursorMode.Auto);

			break;

		}
	}
	private void OnLayerNotHited(){
		
		if(cameraRayCaster.CurrentLayerHited==GameConstants.Layers.None)
		{
			Vector2 hotspotUnknow = new Vector2(unknowCursor.width * relativeCursorOffsetX, unknowCursor.height *relativeCursorOffsetY);
			Cursor.SetCursor(unknowCursor, hotspotUnknow, CursorMode.Auto);
		}
		
	}
	
	// Update is called once per frame

}
