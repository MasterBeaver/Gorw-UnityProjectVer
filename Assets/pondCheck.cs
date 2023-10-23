using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pondCheck : MonoBehaviour
{
    public static Transform spawn;

    private void Start() 
    {
        spawn = gameObject.transform;
    }
    
    public static void ReSpawn(GameObject player)
    {
        player.transform.position = spawn.position;
    }
}
