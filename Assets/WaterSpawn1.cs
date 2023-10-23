using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawn1 : MonoBehaviour
{
    public string phase;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == phase)
        {
            pondCheck.ReSpawn(other.gameObject);
        }
    }
}
