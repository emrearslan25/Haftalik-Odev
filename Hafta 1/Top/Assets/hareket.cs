using UnityEngine;

public class hareket : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody rb;

    void Start()
    {
        // Rigidbody component'ini al
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Yatay ve dikey input'ları al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Hareket yönünü belirle
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        
        // Kamera yönüne göre hareket vektörünü ayarla
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        
        // Y (yukarı/aşağı) bileşenini sıfırla
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        
        // Vektörleri normalize et
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Kamera yönüne göre hareket vektörünü hesapla
        Vector3 moveDirection = cameraRight * horizontalInput + cameraForward * verticalInput;

        // Kuvvet uygula
        rb.AddForce(moveDirection * moveSpeed);
    }
}
