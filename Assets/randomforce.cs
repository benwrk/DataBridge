using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomforce : MonoBehaviour {
    public static float speed { get; set; }
    // Use this for initialization
    Vector3 randomDirection = new Vector3(Random.value, Random.value, Random.value);
    
    void Start () {

        transform.Rotate(randomDirection);
    }

    // Update is called once per frame
    void Update () {
        // transform.position += transform.forward * speed * Time.deltaTime;
        
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }



}
