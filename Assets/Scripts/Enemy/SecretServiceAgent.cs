using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Collider), typeof(Rigidbody))]
public class SecretServiceAgent : MonoBehaviour
{
    public List<Transform> PatrolPoints = new List<Transform>();

    [SerializeField]
    private float _stoppingDistance = 0.3f;

    private NavMeshAgent _agent;
    private float _maxDistance = 5;
    private WaveExpander _examinedSound;
    private Transform _myTransform;

    private Vector3 _nextPatrolPoint;
    private Queue<Vector3> _patrolPoints = new Queue<Vector3>();

    // Use this for initialization
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _myTransform = GetComponent<Transform>();

        if (PatrolPoints.Count > 0)
        {
            PatrolPoints.ForEach(point => _patrolPoints.Enqueue(point.position));
            _nextPatrolPoint = _patrolPoints.Dequeue();
            if (_agent)
            {
                _agent.SetDestination(_nextPatrolPoint);
            }
        }
    }

    void Update()
    {
        if (_examinedSound)
        {
            if (Vector3.Distance(_myTransform.position, _examinedSound.transform.position) <= _stoppingDistance)
            {
                if (_agent)
                {
                    _examinedSound = null;
                    _agent.Stop();
                }
            }
        }
        else if (_patrolPoints.Count > 0)
        {
            if (Vector3.Distance(_myTransform.position, _nextPatrolPoint) <= _stoppingDistance)
            {

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        WaveExpander wave = other.GetComponent<WaveExpander>();
        if (wave && wave != _examinedSound)
        {
            _examinedSound = wave;
            _agent.SetDestination(wave.transform.position);

            if (_agent.path.status == NavMeshPathStatus.PathComplete)
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
