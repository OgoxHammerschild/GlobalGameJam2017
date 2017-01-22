using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Collider), typeof(Rigidbody))]
public class SecretServiceAgent : MonoBehaviour
{
    public List<Transform> PatrolPoints = new List<Transform>();
    public bool IsSleeping = false;

    [SerializeField]
    private float _stoppingDistance = 0.3f;

    private NavMeshAgent _agent;
    private float _maxPathDistance = 5;
    private WaveExpander _examinedSound;
    private Transform _myTransform;

    private Vector3 _nextPatrolPoint;
    private Queue<Vector3> _patrolPoints = new Queue<Vector3>();
    private Vector3 _originalPosition;

    private Transform _player;

    [SerializeField]
    private float _fieldOfView = 120;

    // Use this for initialization
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _myTransform = GetComponent<Transform>();

        if (PatrolPoints.Count > 0)
        {
            foreach (var point in PatrolPoints)
            {
                _patrolPoints.Enqueue(point.position);
            }

            _nextPatrolPoint = _patrolPoints.Dequeue();
            if (_agent)
            {
                _agent.SetDestination(_nextPatrolPoint);
            }
        }

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _originalPosition = _myTransform.position;
    }

    void Update()
    {
        if (IsSleeping)
            return;

        if (!_agent)
        {
            print(name + " needs a NavMeshAgent-Component");
            return;
        }

        if (CanSeePlayer())
        {
            _agent.SetDestination(_player.position);
            return;
        }
        else if (_agent.destination != _nextPatrolPoint)
        {
            if (Vector3.Distance(_myTransform.position, _nextPatrolPoint) > _stoppingDistance)
            {
                _agent.SetDestination(_nextPatrolPoint);
            }
            else
            {
                _agent.Stop();
            }
        }

        if (_examinedSound)
        {
            if (Vector3.Distance(_myTransform.position, _examinedSound.transform.position) <= _stoppingDistance)
            {
                _examinedSound = null;
                if (_patrolPoints.Count > 0)
                {
                    _agent.SetDestination(_nextPatrolPoint);
                }
                else
                {
                    _agent.Stop();
                }
            }
        }
        else if (_patrolPoints.Count > 0)
        {
            if (Vector3.Distance(_myTransform.position, _nextPatrolPoint) <= _stoppingDistance)
            {
                _patrolPoints.Enqueue(_nextPatrolPoint);
                _nextPatrolPoint = _patrolPoints.Dequeue();
                _agent.SetDestination(_nextPatrolPoint);
                _agent.Resume();
            }
        }
        else if(Vector3.Distance(_myTransform.position, _originalPosition) <= _stoppingDistance)
        {
            _agent.SetDestination(_originalPosition);
            _nextPatrolPoint = _originalPosition;
            _agent.Resume();
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
                if (_agent.remainingDistance > _maxPathDistance)
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //Destroy(collision.collider.gameObject);
        }
    }

    private bool CanSeePlayer()
    {
        if (!_player)
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            if (!_player)
            {
                print(name + " has no player");
                return false;
            }
        }

        RaycastHit hit;
        Vector3 rayDirection = _player.position - _myTransform.position;

        if (Mathf.Abs(Vector3.Angle(rayDirection, transform.forward)) <= _fieldOfView / 2)
        {
            if (Physics.Raycast(_myTransform.position, rayDirection, out hit, 1, 1 << LayerMask.NameToLayer("Player"), QueryTriggerInteraction.Ignore))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    print("Hit");
                    return true;
                }
            }
        }
        return false;
    }
}
