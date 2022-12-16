using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveWithMouse();
    }

    void moveWithMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        lookAtMouse(mousePos);
    }

    void lookAtMouse(Vector3 mousePos)
    {
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
