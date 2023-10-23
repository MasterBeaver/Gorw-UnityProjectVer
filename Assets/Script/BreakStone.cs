using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakStone : MonoBehaviour
{
    public ParticleSystem paStone;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Stone")
        {
            Destroy(other.gameObject);
            Instantiate(paStone, transform.position, paStone.transform.rotation);
        }
    }
}
    