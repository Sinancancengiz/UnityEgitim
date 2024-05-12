using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;    // hareket hýzý
    public float rotationSpeed = 10f;
    private Rigidbody rb;   // fizik iþlemleri için rigidboy'i tanýmladýk
    private Animator animator;  // Animasyon iþlemleri için
    public List<GameObject> goldList;   // Karakterin elindeki altýnlarý tutan liste
    public int carry;   // Gold counter
    
    public float reduceSpeed = 0.5f;
    private float baseMovementSpeed;

    public int carryLimit => goldList.Count;    // Taþýma limiti

    private void Start()
    {
        baseMovementSpeed = movementSpeed;
        rb = GetComponent<Rigidbody>(); // Ayný GameObject üzerindeki rigidbody'e ulaþmak için GetComponent fonksiyonu kullanýldý
        // Ulaþmak için GetComponent fonksiyonu

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Yatay eksende giriþ
        var vertical = Input.GetAxis("Vertical");   // Alternatif tanýmlama

        // Hareket uzayýnýn 2 boyuta indirgenmesi
        // X ve Y ekseni üzerindeki hareket giriþleri X ve Z eksenleri olmak üzere dönüþtürüldü.
        var movementDirection = new Vector3(-horizontal, 0, -vertical);

        animator.SetBool("isRunning", movementDirection != Vector3.zero);   // Ya bu ya da alttaki
        //animator.SetBool("isRunning", rb.velocity != Vector3.zero);   // Ýkisinden birisi

        animator.SetBool("isCarrying", carry != 0);

        if (movementDirection == Vector3.zero)
        {
            Debug.Log("Input yok");
            rb.velocity = Vector3.zero;
            return;
        }

        rb.velocity = movementDirection * movementSpeed;    // Hareket vektörüne hareket unsurlarý verildi.

        // Movement drection yönünü ratation olarak kaydet.
        var rotationDirection = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationDirection, rotationSpeed * Time.deltaTime);
    }

    public bool CollectGold()
    {
        if (carry == carryLimit) return false;
        
        goldList[carry].gameObject.SetActive(true);
        carry++;

        movementSpeed -= reduceSpeed;

        return true;   
    }

    public int LoadGoldstoTruck()
    {
        var carryingGold = carry;
        if (carryingGold == 0) return 0;

        foreach (var gold in goldList)
        {
            gold.SetActive(false);  // gameObject.gameObject.gameObject.gameObject diye gidebilirim. gold zaten bir gameObject.
                                    // Yazmaya gerek yok.
        }

        carry = 0;
        movementSpeed = baseMovementSpeed;
        //movementSpeed += carryingGold * reduceSpeed;
        return carryingGold;
    }
}
