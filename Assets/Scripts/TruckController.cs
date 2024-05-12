using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    public List<GameObject> golds;
    public GameObject goldsParent;
    private int currentGold;

    private void Start()
    {
        golds = new List<GameObject>();
        foreach (Transform gold in goldsParent.transform)
        {
            golds.Add(gold.gameObject);
            gold.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return; // ... deðilse, fonksion içinden çýk
        var player = collision.gameObject.GetComponent<PlayerController>();

        var gold = player.LoadGoldstoTruck();
        currentGold += gold;

        for (int i = 0; i < currentGold; i++)
        {
            golds[i].SetActive(true);
        }
    }
}
