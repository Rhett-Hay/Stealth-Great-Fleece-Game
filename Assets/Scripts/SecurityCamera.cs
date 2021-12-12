using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverCutscene;
    [SerializeField]
    private Animator _anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            Color color = new Color(.7f, .2f, .2f, .05f);
            renderer.material.SetColor("_TintColor", color);
            _anim.enabled = false;
            StartCoroutine(AlertRoutine());
        }
    }

    IEnumerator AlertRoutine()
    {
        yield return new WaitForSeconds(.5f);
        _gameOverCutscene.SetActive(true);      
    }
}
