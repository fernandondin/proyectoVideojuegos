using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public CameraController camera;
    public float moveSpeed = 10f;
    private float xInput;
    private float zInput;
    public float jumpForce = 0.2f;
    // Start is called before the first frame update
    void Awake(){
        rb = GetComponent<Rigidbody>();
        Debug.Log("Player has awoken");
        Debug.Log(gameObject.name);
        Debug.Log(gameObject.tag);
    }

    // Update is called once per frame
    void Update(){
     ProcessInputs(); 
    }

    private void FixedUpdate(){
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround()){
            Jump();
        }
        if (Input.GetMouseButtonDown(0)){
            Scalling();
        }
    }

    private void ProcessInputs(){
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

    }
    private void Move(){
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }
    private void Jump(){
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    /*Para que no salte en el aire*/
    private bool isOnGround(){
        return Physics.Raycast(transform.position, Vector3.down, 1f);
    }
    /*Testeando escalar la canica*/
    private void Scalling(){
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        camera.zOffSet -= 0.5f;
    }

}
