using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatil : MonoBehaviour
{
    public bool teeeeee;
    public ParticleSystem paStone;

    private void Update() {
        if(teeeeee == true)
        {
            Instantiate(paStone, transform.position, paStone.transform.rotation);
            teeeeee = false;
        }
    }
}
