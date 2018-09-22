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

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (cameraRayCaster.IsHited)
        {
            switch(cameraRayCaster.LayerHited)
            {
               
                case GameConstants.Layers.Enemy:
                    Vector2 hotspotEnemy = new Vector2(enemyCursor.width * 0.5f, enemyCursor.height * 0.5f);
                    Cursor.SetCursor(enemyCursor, hotspotEnemy, CursorMode.ForceSoftware);
                    break;
                case GameConstants.Layers.Walkable:
                    Vector2 hotspotWalk = new Vector2(walkCursor.width * 0.5f, walkCursor.height * 0.5f);
                    Cursor.SetCursor(walkCursor, hotspotWalk, CursorMode.ForceSoftware);

                    break;
               
            }
        }
        else
        {
             if(cameraRayCaster.LayerHited==GameConstants.Layers.None)
            {
                Vector2 hotspotUnknow = new Vector2(unknowCursor.width * 0.5f, unknowCursor.height * 0.5f);
                Cursor.SetCursor(unknowCursor, hotspotUnknow, CursorMode.ForceSoftware);
            }
                 

          
        }
		
	}
}
