using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject ball;
    public GameObject p1;
    public GameObject p2;
    public GameObject p1Border;
    public GameObject p2Border;

    public Text p1TextScore;
    public Text p2TextScore;

    public int p1Score;

    public int p2Score;

    public Text P1PowerUp;
    public Text P2PowerUp;


    public void P1Scored()
    {
        p1Score++;
        p1TextScore.text = p1Score.ToString();
        if (p1Score == 3)
        {
            p1TextScore.fontSize = 70;
            p1TextScore.text = "WINNER P1";
            p2TextScore.text = "";

        }
        else
        {
            ResetPosition();
        }

    }

    public void P2Scored()
    {
        p2Score++;
        p2TextScore.text = p2Score.ToString();

        if (p2Score == 3)
        {
            p1TextScore.text = "";
            p2TextScore.text = "WINNER P2";
            p2TextScore.fontSize = 70;
        }
        else
        {
            ResetPosition();
        }
    }


    IEnumerator displayPowerUptext(string powerUp, string player)
    {
        if (player == "p2")
        {
            P1PowerUp.text = powerUp;
        }
        else
        {
            P2PowerUp.text = powerUp;
        }
        yield return new WaitForSeconds(2f);
        P1PowerUp.text = "";
        P2PowerUp.text = "";

    }

    public void initCoroutine(string powerUp, string player)
    {
        StartCoroutine(displayPowerUptext(powerUp, player));
    }


    public void ResetPosition()
    {
        ball.GetComponent<BallMovement>().Reset();
        p1.GetComponent<Player1MovementScript>().Reset();
        p2.GetComponent<Player2Movement>().Reset();
    }
}
