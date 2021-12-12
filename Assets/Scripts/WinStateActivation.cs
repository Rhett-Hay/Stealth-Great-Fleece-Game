using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    public GameObject _winCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            if (GameManager.Instance.HasCard == true)
            {
                _winCutscene.SetActive(true);
            }
            else
            {
                Debug.Log("You must grab the key card!");
            }
        }
    }
}
