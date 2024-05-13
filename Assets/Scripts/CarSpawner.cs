using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public List<GameObject> carPrefabs;

    public float minTime, maxTime;

    public float timer;
    public float spawnTime;

    private void Start()
    {
        spawnTime = Random.Range(minTime, maxTime); // Ýlk oluþma süresi
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)    // Spawn time => 3.2436 olduðunda tam tutturmasý zor olabilir. O kadar hassas olmamalý.
        { 
            timer = 0; // Kontrolden çýkýlmadan önce birkaç kez daha çalýþabilir. çalýþýr çalýþmaz 0 yapýldý ki hýz yüzünden çalýþmasýn.
            var car = carPrefabs[Random.Range(0, carPrefabs.Count)];

            var spawnedCar = Instantiate(car, transform.position, transform.rotation, transform);
            
            spawnedCar.AddComponent<CarController>();

            Destroy(spawnedCar.gameObject, 5f);

            spawnTime = Random.Range(minTime, maxTime); // Ýlk oluþtuktan sonra oluþmalar için süre
        }

    }

}
