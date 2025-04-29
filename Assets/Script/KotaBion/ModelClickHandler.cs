using UnityEngine;

public class ModelClickHandler : MonoBehaviour
{
    public GameObject prefabToSpawn;    // Prefab yang mau di-spawn
    public Transform spawnPoint;        // Lokasi spawn (opsional)
    public Vector3 spawnScale = Vector3.one;    // Scale custom untuk object yang di-spawn
    public Vector3 spawnRotation = Vector3.zero; // Rotasi custom untuk object yang di-spawn (Euler)

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Klik kiri mouse
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform) // Pastikan yang diklik object ini
                {
                    SpawnPrefab();
                }
            }
        }
    }

    private void SpawnPrefab()
    {
        if (prefabToSpawn != null)
        {
            Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position + Vector3.up * 2f;
            Quaternion spawnQuaternion = Quaternion.Euler(spawnRotation); // Konversi rotasi dari Vector3 ke Quaternion

            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, spawnQuaternion);

            spawnedObject.transform.localScale = spawnScale; // Set scale setelah Instantiate
        }
    }
}
