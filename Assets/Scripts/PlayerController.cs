using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;    // hareket h�z�
    public float rotationSpeed = 10f;
    private Rigidbody rb;   // fizik i�lemleri i�in rigidboy'i tan�mlad�k
    private Animator animator;  // Animasyon i�lemleri i�in


    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Ayn� GameObject �zerindeki rigidbody'e ula�mak i�in GetComponent fonksiyonu kullan�ld�
        // Ula�mak i�in GetComponent fonksiyonu

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Yatay eksende giri�
        var vertical = Input.GetAxis("Vertical");   // Alternatif tan�mlama

        // Hareket uzay�n�n 2 boyuta indirgenmesi
        // X ve Y ekseni �zerindeki hareket giri�leri X ve Z eksenleri olmak �zere d�n��t�r�ld�.
        var movementDirection = new Vector3(horizontal, 0, vertical);

        animator.SetBool("isRunning", movementDirection != Vector3.zero);   // Ya bu ya da alttaki
        //animator.SetBool("isRunning", rb.velocity != Vector3.zero);   // �kisinden birisi

        if (movementDirection == Vector3.zero)
        {
            Debug.Log("Input yok");
            rb.velocity = Vector3.zero;
            return;
        }

        rb.velocity = movementDirection * movementSpeed;    // Hareket vekt�r�ne hareket unsurlar� verildi.

        // Movement drection y�n�n� ratation olarak kaydet.
        var rotationDirection = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationDirection, rotationSpeed * Time.deltaTime);
    }

}
