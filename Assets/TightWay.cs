using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TightWay : MonoBehaviour
{
    public List<SecretServiceAgent> Agents = new List<SecretServiceAgent>();
    public List<Transform> Doors = new List<Transform>();

    private Transform _player;
    private bool _wasFired = false;

    public void StartAlarm()
    {
        if (_wasFired)
            return;

        _wasFired = true;

        foreach (var door in Doors)
        {
            StartCoroutine(OpenDoor(door));
        }

        foreach (var agent in Agents)
        {
            agent.IsSleeping = false;
            NavMeshAgent navAgent = agent.GetComponent<NavMeshAgent>();
            if (navAgent)
            {
                if (!_player)
                {
                    _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
                }
                navAgent.SetDestination(_player.position);
            }
        }
    }

    IEnumerator OpenDoor(Transform door, float rotatedDistance = 0)
    {
        float rotationPerSecond = 40;
        float angle = 90 * Time.deltaTime * rotationPerSecond;
        door.Rotate(Vector3.up, -angle);
        rotatedDistance += angle;

        yield return new WaitForEndOfFrame();
        if (rotatedDistance < 90)
        {
            StartCoroutine(OpenDoor(door, rotatedDistance));
        }
    }
}
