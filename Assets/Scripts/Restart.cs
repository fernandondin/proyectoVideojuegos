using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject player;
    public CameraController camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - new Vector3(0, 10, 0);
        transform.position = new Vector3(transform.position.x, -10, transform.position.z);
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "CanicaPlayer"){
            other.gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }
}
