using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAndDie : MonoBehaviour
{
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move continuously to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // door starting, center and end point
        float doorBounds = GameObject.Find("Door").GetComponent<Collider>().bounds.size.x;
        float centerPoint = GameObject.Find("Door").GetComponent<Collider>().bounds.center.x;
        float startPoint = centerPoint + (doorBounds / 2);
        float endPoint = centerPoint - (doorBounds / 2);
        // destroy when reaching door and door is lowered
        bool isDoorDown = GameObject.Find("Door").GetComponent<moveDoor>().isDoorDown;
        if (isDoorDown && transform.position.x <= startPoint && transform.position.x >= endPoint) {
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
        
        // destroy when reaching point of death (out of vision)
        if (transform.position.x <= GameObject.Find("DeathZone").transform.position.x) {
            gameObject.SetActive(false);
            Destroy(gameObject, 0.5f);
        }
    }
}
