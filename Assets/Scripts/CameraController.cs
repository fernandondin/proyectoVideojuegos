using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float xOffSet;
    public float yOffSet;
    public float zOffSet;
    public float speed = 3f;
    public float orbitDistance = 5f;
    public float orbitDegreesPerSec = 1.0f;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position + new Vector3(xOffSet, yOffSet, zOffSet);
        Orbit();
        transform.LookAt(player.transform.position);
        //transform.RotateAround(player.transform.position , Vector3.up, Input.GetAxis("Mouse X") * speed);
        
    }   
    void Orbit()
     {
         if(player != null)
         {
            
             transform.position = player.transform.position + (transform.position - player.transform.position).normalized * orbitDistance;
             transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxis("Mouse X") * speed );
         }
     }
}
