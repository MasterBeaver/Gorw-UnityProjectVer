using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public string mainMenu;
    
    private void Start() {
        StartCoroutine(WaitAndSkip());
    }
    
    
    private IEnumerator WaitAndSkip()
    {
        
        yield return new WaitForSeconds(33f);
        SceneManager.LoadScene(mainMenu);
        
    }
}
