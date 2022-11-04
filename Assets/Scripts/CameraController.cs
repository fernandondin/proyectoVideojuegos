using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float xOffSet;
    public float yOffSet;
    public float zOffSet;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(xOffSet, yOffSet, zOffSet);
        transform.LookAt(player.transform);
    }
}
