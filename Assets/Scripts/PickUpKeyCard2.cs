using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKeyCard2 : MonoBehaviour {

    private Movement _player;

    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Movement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player.gameObject)
        {
            _player.HasKeyCard2 = true;
            Destroy(this.gameObject);
        }
    }
}
