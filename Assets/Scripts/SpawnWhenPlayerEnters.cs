using UnityEngine;

public class SpawnWhenPlayerEnters : MonoBehaviour {

    public GameObject spawnPoint;
    public GameObject toSpawn;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        Instantiate(toSpawn, spawnPoint.transform.position, Quaternion.identity);

        rb.gameObject.SetActive(false);
    }
}
