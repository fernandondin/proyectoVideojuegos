using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public CameraController camera;
    public float moveSpeed = 10f;
    private float xInput;
    private float zInput;
    public float jumpForce = 0.2f;
    public int coins = 0;
    public int totalCoins;
    public Text coinsText;
    public string sceneName;
    // Start is called before the first frame update
    void Awake(){
        rb = GetComponent<Rigidbody>();
        Debug.Log("Player has awoken");
        Debug.Log(gameObject.name);
        Debug.Log(gameObject.tag);
    }

    // Update is called once per frame
    void Update(){
     //ProcessInputs(); 

    }

    private void FixedUpdate(){
        if(totalCoins == coins){
            SceneManager.LoadScene(sceneName);
        }
        coinsText.text = coins.ToString()+"/"+totalCoins.ToString();
        //Move();
        MovePlayerRelativeToCamera();
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround()){
            Jump();
        }
    }

    private void rotateLeft(){
        transform.Rotate(0, -1, 0);
    }
    private void ProcessInputs(){
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

    }
    private void MovePlayerRelativeToCamera(){
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        Vector3 forwardRelativeVerticalInput = forward * playerVerticalInput;
        Vector3 rightRelativeHorizontalInput = right * playerHorizontalInput;
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;
        this.transform.Translate(cameraRelativeMovement * moveSpeed * Time.deltaTime, Space.World);
        
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
    private void ScallingDown(float scale){
        transform.localScale -= new Vector3(scale, scale, scale);
    }
    private void ScallingUp(float scale){
        transform.localScale += new Vector3(scale, scale, scale);
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.name.Contains("Moneda")){
            coins++;
        }
        if (other.gameObject.name.Contains("Jumper")){
            JumpHightPerTime(8);
        }
        if (other.gameObject.name.Contains("Smaller")){
            ScallingDown(1.5f);
        }
        if (other.gameObject.name.Contains("Bigger")){
            ScallingUp(1.5f);
        }
        if (other.gameObject.name.Contains("Slime") || other.gameObject.name.Contains("Tortuga")){
            transform.position = new Vector3(0, 3, 0);
        }
    }
    void JumpHightPerTime(int time){
        for (int i = 0; i < time; i++){
            Jump();
        }
    }

}
