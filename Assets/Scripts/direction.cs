using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direction : MonoBehaviour
{

     private float speed = 20f;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
