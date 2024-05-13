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
        spawnTime = Random.Range(minTime, maxTime); // �lk olu�ma s�resi
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)    // Spawn time => 3.2436 oldu�unda tam tutturmas� zor olabilir. O kadar hassas olmamal�.
        { 
            timer = 0; // Kontrolden ��k�lmadan �nce birka� kez daha �al��abilir. �al���r �al��maz 0 yap�ld� ki h�z y�z�nden �al��mas�n.
            var car = carPrefabs[Random.Range(0, carPrefabs.Count)];

            var spawnedCar = Instantiate(car, transform.position, transform.rotation, transform);
            
            spawnedCar.AddComponent<CarController>();

            Destroy(spawnedCar.gameObject, 5f);

            spawnTime = Random.Range(minTime, maxTime); // �lk olu�tuktan sonra olu�malar i�in s�re
        }

    }

}
