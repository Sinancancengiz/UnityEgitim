using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public GameObject goldObject;

    public bool isGoldCollectable => goldObject.activeSelf;
    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!isGoldCollectable) return; // ... deðilse, fonksion içinden çýk

        if (collision.gameObject.tag != "Player") return; // ... deðilse, fonksion içinden çýk
        var player = collision.gameObject.GetComponent<PlayerController>();

        if (player.collectGold())
        {
            goldObject.SetActive(false);
            Invoke(nameof(ReloadGold), Random.Range(5f, 15f));  // Zaman olduðu için float
        }
    }

    private void ReloadGold()
    {
        goldObject.SetActive(true);
    }
}
