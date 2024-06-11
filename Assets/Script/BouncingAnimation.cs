using UnityEngine;

public class BouncingAnimation : MonoBehaviour
{
    // Batas atas dan bawah dari animasi
    public float upperBound = 2.0f;
    public float lowerBound = 0.0f;

    // Kecepatan dari animasi
    public float speed = 1.0f;

    // Arah gerakan: 1 = naik, -1 = turun
    private int direction = 1;

    void Update()
    {
        // Hitung posisi baru
        float newY = transform.position.y + direction * speed * Time.deltaTime;

        // Cek apakah sudah mencapai batas atas atau bawah
        if (newY > upperBound)
        {
            newY = upperBound;
            direction = -1; // Ubah arah ke bawah
        }
        else if (newY < lowerBound)
        {
            newY = lowerBound;
            direction = 1; // Ubah arah ke atas
        }

        // Update posisi objek
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
