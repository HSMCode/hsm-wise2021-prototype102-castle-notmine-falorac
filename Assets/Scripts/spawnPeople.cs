using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPeople : MonoBehaviour
{
    // prefab variables
    public GameObject farmer;
    public GameObject thief;
    private Vector3 position;
    private float randomZPosition;
    public float spawnDelay = 1.0f;
    public float spawnTimer = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        InvokeRepeating("Spawning", spawnDelay, spawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Spawning() {
        // Spawn person at gameObject location (random x position)
        randomZPosition = Random.Range(transform.position.z - 3f, transform.position.z + 2.5f);
        position.z = randomZPosition;
        GameObject instanciatedPerson = Instantiate(farmer, position, Quaternion.identity, this.gameObject.transform);
    } 
}
