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
    public float spawnTimer = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // repeat spawning of people after seconds (spawnDelay) at interval (spawnTimer)
        position = transform.position;
        InvokeRepeating("Spawning", spawnDelay, spawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Spawning() {
        // Choose type of spawning person randomly (farmers more likely)
        float choosePerson = Random.Range(0.0f, 1.0f);
        GameObject chosenPerson;
        if (choosePerson < 0.8f) {
            chosenPerson = farmer;
        } else {
            chosenPerson = thief;
        }

        // Spawn person at gameObject location with random z position on path
        randomZPosition = Random.Range(transform.position.z - 2.8f, transform.position.z + 2.5f);
        position.z = randomZPosition;
        GameObject instanciatedPerson = Instantiate(chosenPerson, position, Quaternion.identity, this.gameObject.transform);
    } 
}
