using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    // Create a handle to hold the NavMeshAgent
    private NavMeshAgent _agent;

    // Create a handle to hold the Animator
    private Animator _anim;
    // Prefab of the coin
    [SerializeField]
    private GameObject _coinPrefab;
    [SerializeField]
    private AudioClip _coinSound;

    // Start is called before the first frame update
    private void Start()
    {
        // assign the handle to the NavMesh component
        _agent = GetComponent<NavMeshAgent>();
        // assign the handle to the Animator component
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Cast a ray from the mouse position
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                _agent.destination = hitInfo.point;
            }
        }

        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _anim.SetBool("Walk", false);
        }
        else
        {
            _anim.SetBool("Walk", true);
        }

        // if right-click
        /*if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                // Instantiate coin at clicked point
                Instantiate(_coinPrefab, hitInfo.point, Quaternion.identity);
                // play coin audio sound
                AudioSource.PlayClipAtPoint(_coinSound, hitInfo.point);
            }

        }*/

    }
}