using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;    // hareket h�z�
    public float rotationSpeed = 10f;
    private Rigidbody rb;   // fizik i�lemleri i�in rigidboy'i tan�mlad�k

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Ayn� GameObject �zerindeki rigidbody'e ula�mak i�in GetComponent fonksiyonu kullan�ld�
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Yatay eksende giri�
        var vertical = Input.GetAxis("Vertical");   // Alternatif tan�mlama

        // Hareket uzay�n�n 2 boyuta indirgenmesi
        // X ve Y ekseni �zerindeki hareket giri�leri X ve Z eksenleri olmak �zere d�n��t�r�ld�.
        var movementDirection = new Vector3(horizontal, 0, vertical);

        if (movementDirection == Vector3.zero)
        {
            Debug.Log("Input yok");
            return;
        }

        rb.velocity = movementDirection * movementSpeed;    // Hareket vekt�r�ne hareket unsurlar� verildi.

        // Movement drection y�n�n� ratation olarak kaydet.
        var rotationDirection = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationDirection, rotationSpeed * Time.deltaTime);
    }

}