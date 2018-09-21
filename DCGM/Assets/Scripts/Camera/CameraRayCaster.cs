using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraRayCaster : MonoBehaviour {

    // Use this for initialization
    
    [SerializeField]
    private GameConstants.Layers[] layerPriorities = { GameConstants.Layers.Enemy, GameConstants.Layers.Walkable };
    [SerializeField]
    float maxRayDistance=100;
    private GameConstants.Layers layerHited;
    private RaycastHit hit;
    private Camera viewCam;
    private string nameLayerHited;
    private int index=0;
    
    public RaycastHit Hit
    {
        get { return hit; }
    }
   
    public GameConstants.Layers LayerHited
    {
        get { return layerHited; }
    }
    public string NameLayerHited
    {
        get { return nameLayerHited; }
    }
    public bool IsHited
    {
        get { return isHited; }
    }
    bool isHited = false;



    void Start () {
        viewCam = Camera.main;
		
	}
	
	// Update is called once per frame
	void Update () {
       
        //si se ha hecho un hit con el raycast en la prioridad definida detendremos el proceso del update para mantener almacenado los valores relacionados con el ultimo hit.
       //si no encuentra ningun hit, osea el codigo nunca se detiene, asignaremos los valores para "hit ninguno"
       

        for(int i = 0; i < layerPriorities.Length; i++)
        {
            RaycastFromCamera(layerPriorities[i]);
            if (isHited)
                return;

        }

        Debug.Log(nameLayerHited);
        nameLayerHited = Enum.GetName(typeof(GameConstants.Layers), GameConstants.Layers.None);
        layerHited = GameConstants.Layers.None;
       



    }

    private void RaycastFromCamera(GameConstants.Layers layer)
    {
        int layerMask = 1 << (int)layer;
        Ray ray = viewCam.ScreenPointToRay(Input.mousePosition);
        isHited = Physics.Raycast(ray,out hit, 100, layerMask);
       

        if (isHited)
        {
            layerHited = layer;
            nameLayerHited = LayerMask.LayerToName((int)layer);
            
            

        }

      

        






    }
   
}
