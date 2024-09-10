using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    public float speed = 1f;
     public float maxSpeed = 1f;

     public float forwardSpeed = 1f;

     public int life = 3;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")){
            life=life-1;

            if(life==0){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            GameObject.Destroy(other.gameObject);
           
        }

        if (other.gameObject.CompareTag("Finish")){
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
