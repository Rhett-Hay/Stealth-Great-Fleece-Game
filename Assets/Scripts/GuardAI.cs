using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    public int _currentTarget;
    private NavMeshAgent _agent;
    private bool _reverse;
    private bool _targetReached;
    private Animator _anim;
    // coin tossed set to false for public access
    public bool coinTossed = false;
    // assign the coin's position
    public Vector3 coinPos;

    // Start is called before the first frame update
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[_currentTarget] != null && coinTossed == false) // coin tossed must equal false
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);

            float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);

            if (distance < 1.0f && (_currentTarget == 0 || _currentTarget == wayPoints.Count - 1))
            {
                if (_anim != null)
                {
                    _anim.SetBool("Patrolling", false);
                }
            }
            else
            {
                if (_anim != null)
                {
                    _anim.SetBool("Patrolling", true);
                }
            }

            if (distance < 1.0f && _targetReached == false)
            {
                _targetReached = true;
                StartCoroutine(GuardDelay());
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, coinPos);

            if (distance < 5.0f)
            {
                _anim.SetBool("Patrolling", false);
                _agent.stoppingDistance = 5;
            }
        }
    }

    IEnumerator GuardDelay()
    {
        if (_currentTarget == 0 || _currentTarget == wayPoints.Count - 1)
        {
            yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
        }
        else
        {
            yield return null;
        }

        if (_reverse == true)
        {
            _currentTarget--;

            if (_currentTarget == 0)
            {
                _reverse = false;
                _currentTarget = 0;
            }
        }
        else if (_reverse == false)
        {
            _currentTarget++;

            if (_currentTarget == wayPoints.Count)
            {
                _reverse = true;
                _currentTarget--;
            }
        }

        _targetReached = false;
    }
}

