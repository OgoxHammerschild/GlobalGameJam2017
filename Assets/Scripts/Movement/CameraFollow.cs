using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    public GameObject Player;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerFollow();
	}

    void PlayerFollow()
    {
        this.gameObject.transform.position = new Vector3(Player.transform.position.x,this.transform.position.y,Player.transform.position.z - 0.5f);
    }
}
