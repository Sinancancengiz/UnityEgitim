using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public GameObject goldObject;

    public bool isGoldCollectable => goldObject.activeSelf;
    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!isGoldCollectable) return; // ... de�ilse, fonksion i�inden ��k

        if (collision.gameObject.tag != "Player") return; // ... de�ilse, fonksion i�inden ��k
        var player = collision.gameObject.GetComponent<PlayerController>();

        if (player.collectGold())
        {
            goldObject.SetActive(false);
        }
    }
}
