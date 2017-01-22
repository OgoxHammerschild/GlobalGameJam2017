using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public GameObject FogOfWarObjects;
	// Use this for initialization
    public void TurnOffFogOfWar()
    {
        FogOfWarObjects.SetActive(false);
    }
}
