using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SecretServiceAgent : MonoBehaviour
{
    private NavMeshAgent _agent;
    private float _maxDistance = 5;

    // Use this for initialization
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        WaveExpander wave = other.GetComponent<WaveExpander>();
        if (wave)
        {
            NavMeshPath path = new NavMeshPath();
            if (_agent.CalculatePath(wave.transform.position, path))
            {
                if (_agent.SetPath(path))
                {
                    if (_agent.remainingDistance > _maxDistance)
                    {
                        _agent.Stop();
                    }
                    else
                    {
                        _agent.Resume();
                    }
                }
            }
        }
    }
}
