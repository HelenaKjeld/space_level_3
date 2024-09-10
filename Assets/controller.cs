using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float speed = 1f;
     public float maxSpeed = 1f;

     public float forwardSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * speed);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * speed);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * speed);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * speed);
        }

               
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
        {
            var direction = gameObject.GetComponent<Rigidbody>().velocity.normalized;
            gameObject.GetComponent<Rigidbody>().velocity = direction * maxSpeed;
        }
    }
}
