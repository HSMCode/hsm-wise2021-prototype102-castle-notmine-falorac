using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnPeople : MonoBehaviour
{
    // prefab variables
    public GameObject farmer;
    public GameObject thief;
    private Vector3 position;
    private float randomZPosition;
    public float spawnDelay = 1.0f;
    public float spawnTimer = 2.0f;

    //private Rigidbody rb; //reference to rigidbody component
    public float speed;
    public float acceleration = 1; //every second the speed will increase this much


    // Start is called before the first frame update
    void Start()
    {
        // repeat spawning of people after seconds (spawnDelay) at interval (spawnTimer)
        position = transform.position;
        InvokeRepeating("Spawning", spawnDelay, spawnTimer);
        //acceleration that doesn't work
        //rb = GetComponent<Rigidbody>();
        //rb.velocity = -transform.forward * speed;

    }

    // Update is called once per frame
    void Update()
    {
        //also acceleration that doesn't work
        //speed += Time.deltaTime * acceleration;
        //rb.velocity = -transform.forward * speed;
    }

    private void Spawning() {
        // Choose type of spawning person randomly (farmers more likely)
        float choosePerson = Random.Range(0.0f, 1.0f);
        GameObject chosenPerson;
        if (choosePerson < 0.5f) {
            chosenPerson = farmer;
        } else {
            chosenPerson = thief;
        }

        // Spawn person at gameObject location with random z position on path
        randomZPosition = Random.Range(transform.position.z - .5f , transform.position.z + 2.5f);
        position.z = randomZPosition;
        GameObject instanciatedPerson = Instantiate(chosenPerson, position, Quaternion.identity, this.gameObject.transform);
    } 
}
