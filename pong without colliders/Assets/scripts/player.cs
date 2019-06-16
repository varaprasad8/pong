using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Transform ball;
    public float ballSpeed;
    Vector3 ballDirection;
    float radius;
    public Text Lscore;
    public Text Rscore;
    private int LS;
    private int RS;

    public Text win;
    

    float verticalExtent;
    float horizontalExtent;

    public Transform LP;
    public Transform RP;
    float paddleLength;



	// Use this for initialization
	void Start ()
    {
        verticalExtent = Camera.main.orthographicSize;
        horizontalExtent = verticalExtent * Camera.main.aspect;

        radius = ball.localScale.y / 2;
        paddleLength = RP.localScale.y / 2;

        LS = 0;
        RS = 0;

        Lscore.text = LS.ToString();
        Rscore.text = RS.ToString();
        win.text = " ";

        ResetBall();
      
	}
	
	// Update is called once per frame
	void Update () {
       ball.position += ballDirection * ballSpeed * Time.deltaTime;
        CheckBallCollisionsWithWalls();
        paddles();
        Score();
        wins();
        //ball.position = ballDirection * ballSpeed * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ResetBall();
        }

    }
    
    void CheckBallCollisionsWithWalls()
    {
        if (ball.position.y+radius > verticalExtent || ball.position.y-radius < -verticalExtent)
            ballDirection.y *= -1;
    }
    void ResetBall()
    {
        ball.position = Vector3.zero;
        ballDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    }

    void paddles()
    {
        if(ball.position.x+radius>=RP.position.x)
        {
            if(ball.position.y>RP.position.y-paddleLength && ball.position.y<RP.position.y+paddleLength)
            {
                ballDirection.x *= -1;
            }
        }
         if (ball.position.x-radius <= LP.position.x)
        {
            if (ball.position.y > LP.position.y-paddleLength && ball.position.y < LP.position.y+paddleLength)
            {
                ballDirection.x *= -1;
            }
        }

    }
    void Score()
    {
        if(ball.position.x>horizontalExtent)
        {
            LS++;
            Lscore.text = LS.ToString();
            ResetBall();
            //Update Score for left 
        }

        if (ball.position.x < -horizontalExtent)
        {
            RS++;
            Rscore.text = RS.ToString();
            ResetBall();
            //Update Score for right 
        }
    }
    void wins()
    {
       
        if (LS == 3)
        {
            win.text = "player1: YOU WON!!!!";
        }
       
        if (RS == 3)
        {
            win.text= "player2: YOU WON!!!!";
        }
    }
}
