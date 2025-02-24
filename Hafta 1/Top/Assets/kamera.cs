using UnityEngine;

public class kamera : MonoBehaviour
{
    public Transform target;        // Takip edilecek top
    public float smoothSpeed = 5f;  // Kamera takip yumuşaklığı
    public Vector3 offset;         // Kamera ile top arasındaki mesafe

    void Start()
    {
        // Başlangıçta kamera ile top arasındaki offset'i kaydet
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        // Topun yeni pozisyonuna göre kameranın olması gereken pozisyonu
        Vector3 desiredPosition = target.position + offset;
        
        // Yumuşak geçiş için lerp kullan
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        // Kameranın pozisyonunu güncelle
        transform.position = smoothedPosition;
        
        // Kameranın hep topa bakmasını sağla
        transform.LookAt(target);
    }
}
