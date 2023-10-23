using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Evolution : MonoBehaviour
{
    private GameObject phase;
    public GameObject phase1;
    public GameObject phase2;
    public GameObject phase3;
    public GameObject phase4;
    private float camDist = -10f;
    private float camY;
    public GameObject player;
    public Vector3 pos;
    private float nextEvoHeight;
    public TMP_Text overheadWarningTxt;
    public static float groundDist;
    public ParticleSystem paLeaf;
    private Color origColor;

    void Start()
    {
        pos = player.transform.position;
        origColor = overheadWarningTxt.color;
        Evolve(0);
        //phase1.SetActive(false);
        //phase2.SetActive(false);
        //phase3.SetActive(false);
        //phase4.SetActive(false);
    }

    //private void Awake()
    //{
    //    phase.transform.position = new Vector3(0,0,0);
    //}

    public void Phase1(Vector3 pos)
    {
        Destroy(phase);
        var newPhase = Instantiate(phase1, pos, Quaternion.identity);
        newPhase.transform.parent = player.transform;
        newPhase.SetActive(true);
        Instantiate(paLeaf, pos, Quaternion.identity);
        phase = newPhase;
    }

    public void Phase2(Vector3 pos)
    {
        Destroy(phase);
        var newPhase = Instantiate(phase2, pos, Quaternion.identity);
        newPhase.transform.parent = player.transform;
        newPhase.SetActive(true);
        Instantiate(paLeaf, pos, Quaternion.identity);
        phase = newPhase;
    }

    public void Phase3(Vector3 pos)
    {
        Destroy(phase);
        var newPhase = Instantiate(phase3, pos, Quaternion.identity);
        newPhase.transform.parent = player.transform;
        newPhase.SetActive(true);
        Instantiate(paLeaf, pos, Quaternion.identity);
        phase = newPhase;
    }

    public void Phase4(Vector3 pos)
    {
        Destroy(phase);
        var newPhase = Instantiate(phase4, pos, Quaternion.identity);
        newPhase.transform.parent = player.transform;
        newPhase.SetActive(true);
        Instantiate(paLeaf, pos, Quaternion.identity);
        phase = newPhase;
    }


    enum Age
    {
        Seed,
        Sapling,
        Tree,
        BigTree
    }

    public void Evolve(int age)
    {
        if (phase != null) { pos = phase.transform.position; }
        //print("Evolved age = " + age.ToString());
        switch ((Age)age)
        {
            case (Age.Seed):
                Phase1(pos);
                nextEvoHeight = 1.0f;
                camDist = -3f;
                camY = 0.9f;
                break;
            case Age.Sapling:
                Phase2(pos);
                nextEvoHeight = 2.1f;
                camDist = -9f;
                camY = 2f;
                groundDist = 0.8f;
                break;
            case (Age.Tree):
                Phase3(pos);
                nextEvoHeight = 100f;
                camDist = -11f;
                camY = 1.5f;
                groundDist = 1.9f;
                break;
            case Age.BigTree:
                Phase4(pos);
                nextEvoHeight = 0.5f;
                camDist = -9f;
                camY = 0.8f;
                break;
        }

    }

    public float GetCamDist()
    {
        return camDist;
    }

    public float GetCamY()
    {
        return camY;
    }

    public GameObject GetPhase()
    {
        return phase;
    }

    public bool CheckCeiling()
    {
        RaycastHit2D checkCeiling = Physics2D.Raycast(phase.transform.position, Vector2.up, nextEvoHeight);
        //print(checkCeiling.collider);
        if (checkCeiling.collider != null) { OverheadWarning(); return false; }
        return true;
    }

    public void OverheadWarning()
    {
        overheadWarningTxt.gameObject.SetActive(true);
        Color targetColor = new Color(0, 0, 0, 0);
        StartCoroutine(LerpFunction(targetColor, 3));
        overheadWarningTxt.color = origColor;
    }
    IEnumerator LerpFunction(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = origColor;
        while (time < duration)
        {
            overheadWarningTxt.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        overheadWarningTxt.color = endValue;
        overheadWarningTxt.gameObject.SetActive(false);
    }

    void Update()
    {
        Debug.DrawRay(phase.transform.position, Vector2.up * nextEvoHeight, Color.red, 10.0f);
    }
}
