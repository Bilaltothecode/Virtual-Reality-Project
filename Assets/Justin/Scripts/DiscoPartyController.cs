using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoPartyController : MonoBehaviour
{
    public GameObject discoParent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            discoParent.SetActive(!discoParent.activeSelf);
    }
}
