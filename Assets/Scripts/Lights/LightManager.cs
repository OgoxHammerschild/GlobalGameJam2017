using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {


    public bool Test;
    public GameObject[] LightObject;
    public SpriteRenderer[] LightRenderer;
	// Use this for initialization
	void Start ()
    {
        EventManager.Lights += TurnLightsOffAndOnAgain;
        LightObject = GameObject.FindGameObjectsWithTag("Light");
        for (int i = 0; i < LightObject.Length; i++)
        {
            LightRenderer[i] = LightObject[i].GetComponent<SpriteRenderer>();
        }
	}

    private void TurnLightsOffAndOnAgain()
    {
        StartCoroutine(TurnAllTheLightsOffAndOn());
    }

    IEnumerator TurnAllTheLightsOffAndOn()
    {
        for (int i = 0; i < LightRenderer.Length; i++)
        {
            LightRenderer[i].enabled = false;
        }
        yield return new WaitForSeconds(.7f);
        for (int i = 0; i < LightRenderer.Length; i++)
        {
            LightRenderer[i].enabled = true;
        }
        yield return new WaitForSeconds(.7f);
        StartCoroutine(TurnAllTheLightsOffAndOn());
    }
}
