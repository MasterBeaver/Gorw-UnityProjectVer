using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    //public Transform player;
    public float camDist;
    public float camY;
    private float camVelocity = 0.0f;
    private float smoothTime = 1.0f;
    public Evolution evo;
    // Update is called once per frame
    public void UpdateCam(float posx, float posy)
    {
        camDist = evo.GetCamDist();
        camY = evo.GetCamY();
        float newZ = Mathf.SmoothDamp(gameObject.transform.position.z, camDist, ref camVelocity, smoothTime);
        //float newY = Mathf.SmoothDamp(gameObject.transform.position.y, player.position.y, ref camVelocity, smoothTime);
        //print("gobj = "+gameObject.transform.position.y);
        //print("player posy = "+player.position.y);
        gameObject.transform.position = new Vector3(posx, posy+camY, newZ);
    }
}
