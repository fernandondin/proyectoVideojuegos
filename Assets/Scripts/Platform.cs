using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private int counter;
    public float speedX;
    public float xOffSet;
    private float originalX;
    // Start is called before the first frame update
    void Start()
    {
        originalX = xOffSet;

    }

    // Update is called once per frame
    void Update(){
        if(xOffSet<=0){
            speedX*=-1;
            xOffSet=originalX;
        }
        transform.position += new Vector3(speedX, 0, 0);
        xOffSet-=speedX;
    }
}
