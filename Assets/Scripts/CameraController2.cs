using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
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
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 21);
        //transform.LookAt(player.transform.position);
        //transform.RotateAround(player.transform.position , Vector3.up, Input.GetAxis("Mouse X") * speed);
        
    }   
    void Orbit()
     {
         if(player != null)
         {
            
             transform.position = player.transform.position + (transform.position - player.transform.position).normalized * orbitDistance;
             transform.RotateAround(new Vector3(0, 0,0), Vector3.up, Input.GetAxis("Mouse X") * speed );
         }
     }
}
