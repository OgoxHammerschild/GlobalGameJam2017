using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingInOut : MonoBehaviour {

    public Image ScreenImage;
    public Transform SpawnPosition;
    public Transform Player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.position = SpawnPosition.position;
        }
    }
}
