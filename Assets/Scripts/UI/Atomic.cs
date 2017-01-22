using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atomic : MonoBehaviour {

    private PlayerStats stats;
    private bool isFinished;
	// Use this for initialization
	void Start ()
    {
        this.stats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        isFinished = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(GetDamage(stats.Nukular));
        }
    }

    IEnumerator GetDamage(int nukular)
    {
        if (Utility.Nukular < 100 && isFinished)
        {
            isFinished = false;
            yield return new WaitForSeconds(1.5f);
            Utility.Nukular++;
            IngameUIEventhandler.F_OnRadioactiveChange(Utility.Nukular++);
            this.stats.Nukular = Utility.Nukular;
            isFinished = true;

        }
        else
        {
            StopCoroutine("GetDamage");
        }
    }
}
