using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {


    public int Nukular;
    public GameObject GObjectToDeactivate;
    public GameObject RadiatedObject;
    public GameObject ChasedObject;

    void Start()
    {
        RadiatedObject.SetActive(false);
        ChasedObject.SetActive(false);

        EventManager.Chase += Chased;
        EventManager.Radiaton += Radiated;
    }

    private void Radiated()
    {
        GObjectToDeactivate.SetActive(false);
        RadiatedObject.SetActive(true);
    }

    private void Chased()
    {
        GObjectToDeactivate.SetActive(false);
        ChasedObject.SetActive(true);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Nukular >= 100)
        {
            EventManager.F_Radiation();
        }	
	}
}
