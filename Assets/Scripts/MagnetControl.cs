using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetControl : MonoBehaviour
{
    public float movementSpeed = 0.2f;

    float movementX;
    float movementY;

    [Header("Positive Borders")]
    public float borderRight = 7.7f;
    public float borderUp = 4f;
    [Header("Negative Borders (Do Not Edit)")]
    public float borderLeft;
    public float borderDown;

    // Start is called before the first frame update
    void Start()
    {
        borderLeft = borderRight * -1;
        borderDown = borderUp * -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Horizontal")
        {
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > borderLeft)
            {
                movementX = -movementSpeed;
            }
            else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < borderRight)
            {
                movementX = movementSpeed;
            }
            else
            {
                movementX = 0;
            }
        }
        if (gameObject.tag == "Vertical")
        {
            if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && transform.position.y > borderDown)
            {
                movementY = -movementSpeed;
            }
            else if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && transform.position.y < borderUp)
            {
                movementY = movementSpeed;
            }
            else
            {
                movementY = 0;
            }
        }
        transform.position += new Vector3(movementX, movementY, 0f);
    }
}
