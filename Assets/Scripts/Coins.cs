using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Coins : MonoBehaviour
{
    [SerializeField]
    private GameObject _coinPrefab;
    [SerializeField]
    private AudioClip _coinSound;
    public bool _coinTossed;
    // handle for the Player's Animator
    private Animator _anim;
    // pass in the hit point
    private Vector3 hit;

    // Start is called before the first frame update
    void Start()
    {
        // get the Player component
        _anim = GameObject.Find("Player").GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        // if right-click
        if (Input.GetMouseButtonDown(1) && _coinTossed == false)
        {
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                hit = hitInfo.point;

                _coinTossed = true;
                // Player Throw animation plays to toss the coin
                _anim.SetTrigger("Throw");
                StartCoroutine(CoinTossDelay(hit));
                SendAItoCoinSpot(hit);
            }
        }
    }

    void SendAItoCoinSpot(Vector3 coinPos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach (var guard in guards)
        {
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            Animator anim = guard.GetComponent<Animator>();
            currentGuard.coinPos = coinPos;

            currentGuard.coinTossed = true;
            currentAgent.SetDestination(coinPos);
            anim.SetBool("Patrolling", true);
        }

    }

    IEnumerator CoinTossDelay(Vector3 hit)
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(_coinPrefab, hit, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_coinSound, hit);
    }
}
