using UnityEngine;

public class SpawnWhenPlayerEnters : MonoBehaviour {

    public GameObject spawnPoint;
    public GameObject toSpawn;

    //public AudioSource LastTransmission;
    
    void OnTriggerEnter(Collider col)
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        //Instantiate(toSpawn, spawnPoint.transform.position, Quaternion.identity);

        toSpawn.SetActive(true);
        gameObject.SetActive(false);
        //LastTransmission.Play();
    }
}
