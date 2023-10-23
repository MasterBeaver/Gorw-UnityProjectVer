using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TimeController : MonoBehaviour
{
    //public GameObject player;
    public TMP_Text timeText;
    public static int time;
    public Evolution evo;
    public int age;
    public static bool stopMovement;
    public Transform slider;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        age = 0;
        timeText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && evo.CheckCeiling())
        {
            StartCoroutine(ChangeYear());
        }
    }

    IEnumerator ChangeYear()
    {
        stopMovement = true;
        var MovementScript = evo.GetPhase().GetComponent<Movement>();
        //MovementScript.enabled = false;
        float t = 0.5f;
        MovementScript.RB.velocity = new Vector2(0f, -1f); ;
        while (Input.GetKey("space") && evo.CheckCeiling())
        {
            
            float valueToLerp = Mathf.Lerp(0.4f, 0.02f, t);//(Start, End, Time)
            t += 5f * Time.deltaTime;
 
            timeText.text = time.ToString() + " Years";

            Vector3 lTemp = slider.transform.localScale;
            lTemp.x = (time % 100f) / 100f ;
            //print(lTemp);
            slider.transform.localScale = lTemp;

            time += 1;
            
            if (time % 100 == 2 && time > 50)
            {
                age += 1;
                if (age > 4) { age = 0; }
                evo.Evolve(age); 

            }
            //print("RampUpTime = " + valueToLerp.ToString());
            yield return new WaitForSeconds(valueToLerp);
        }
        stopMovement= false;    
        //MovementScript.enabled = true;    
    }

    //public void GameStart()
    //{
    //    startButton.gameObject.SetActive(false);
    //    timeText.gameObject.SetActive(true);
    //    evo.Evolve(0);
    //}


}
