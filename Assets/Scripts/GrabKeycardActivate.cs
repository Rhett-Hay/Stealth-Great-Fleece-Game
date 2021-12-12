using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeycardActivate : MonoBehaviour
{
    [SerializeField]
    GameObject _sleepingGuardCutscene;
    [SerializeField]
    GameObject _sleepingGuardCard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            _sleepingGuardCutscene.SetActive(true);
            GameManager.Instance.HasCard = true;
        }

        if (_sleepingGuardCutscene.activeInHierarchy)
        {
            _sleepingGuardCard.SetActive(false);
        }
    }
}
