using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float angle;
    public float distance;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        if (hor != 0){
            angle += hor * Mathf.Deg2Rad;
        }
        
    }
    void LateUpdate(){
        Vector3 orbit = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
        transform.position = pos + orbit * distance;
        transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
    }
    
}
