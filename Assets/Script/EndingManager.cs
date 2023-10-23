using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
     
        if(TimeController.time <= 2000)
        {
            print("Good Ending");
            SceneManager.LoadScene("GoodEnd", LoadSceneMode.Single);
        }
        else
        {
            print("Bad Ending");
            SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
        }
        
    }
}
