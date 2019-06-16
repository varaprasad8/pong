using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private float speed = 5f;
    public GameObject Lpad;
    public GameObject Rpad;

    float verticalExtent;

    Vector2 rPaddleClamp;
    Vector2 lPaddleClamp;

    float paddleLength;

    void Start ()
    {
        verticalExtent = Camera.main.orthographicSize;
        paddleLength = Lpad.transform.localScale.y / 2; 
	}


    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            Lpad.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Lpad.transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Rpad.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Rpad.transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }

        rPaddleClamp = Rpad.transform.position;
        lPaddleClamp = Lpad.transform.position;

        rPaddleClamp.y = Mathf.Clamp(rPaddleClamp.y, -verticalExtent+paddleLength, verticalExtent-paddleLength);
        lPaddleClamp.y = Mathf.Clamp(lPaddleClamp.y, -verticalExtent+paddleLength, verticalExtent-paddleLength);

        Rpad.transform.position = new Vector2(Rpad.transform.position.x, rPaddleClamp.y);
        Lpad.transform.position = new Vector2(Lpad.transform.position.x, lPaddleClamp.y);
    }
}
