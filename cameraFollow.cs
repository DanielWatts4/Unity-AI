using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform target;
    Vector3 velocity = Vector3.zero;
    public float cameraTime = .4f; //Time after moving that the camera begins to follow the player

    //Camera Restrictions 
    public bool yMaxed = false;
    public float yMaxedVal = 0;

    public bool yMin = false;
    public float yMinVal = 0;

    public bool xMaxed = false;
    public float xMaxedVal = 0;

    public bool xMin = false;
    public float xMinVal = 0; 

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position;//tracks the position of the player
        if(yMaxed && yMin)
            targetPosition.y = Mathf.Clamp(target.position.y, yMinVal, yMaxedVal);
        
        else if (yMin)
        
            targetPosition.y = Mathf.Clamp(target.position.y, yMinVal, target.position.y);
        
        else if (yMaxed)
        
            targetPosition.y = Mathf.Clamp(target.position.y, target.position.y, yMaxedVal);


        if (xMaxed && xMin)
            targetPosition.x = Mathf.Clamp(target.position.x, xMinVal, xMaxedVal);

        else if (yMin)

            targetPosition.x = Mathf.Clamp(target.position.x, xMinVal, target.position.x);

        else if (xMaxed)

            targetPosition.x = Mathf.Clamp(target.position.x, target.position.x, xMaxedVal);






        targetPosition.z = transform.position.z; //Adjusts camera position based on player position changes
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, cameraTime); // the overall transition that the camera uses to follow the player, including the delay 'cameraTime'.
    }
}
