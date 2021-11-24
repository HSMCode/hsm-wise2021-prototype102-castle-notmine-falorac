using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDoor : MonoBehaviour
{
    public Transform pivotObject;
    public float speed = 5.0f;
    private float doorRotation = 101.0f;
    public bool isDoorDown;

    // Start is called before the first frame update
    void Start()
    {
        isDoorDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        // rotate door
        if(Input.GetKeyDown(KeyCode.Space)) {
            if (isDoorDown) {
                transform.RotateAround(pivotObject.position, Vector3.right * speed * Time.deltaTime, doorRotation);
                isDoorDown = false;
            } else {
                transform.RotateAround(pivotObject.position, Vector3.left * speed * Time.deltaTime, doorRotation);
                isDoorDown = true;
            }
        }
    }
}
