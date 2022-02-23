using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpScript : MonoBehaviour
{

    private GameObject ball;
    private GameObject player1;
    private GameObject player2;

    private GameObject camera;

    private GameObject gameManager;

    public Text p1PowerUp;
    public Text p2PowerUp;

    int[] array2 = new int[] { 1, 2 };

    private int chosenPower;


    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        camera = GameObject.Find("Main Camera");

        gameManager = GameObject.Find("GameManager");

        createPowerUp();

    }

    // Update is called once per frame
    void Update()
    {

    }


    void createPowerUp()
    {
        System.Random random = new System.Random();
        chosenPower = random.Next(1, 3);
        Debug.Log("chosen : " + chosenPower);
    }


    public void freeze(string lastPlayed)
    {

        if (lastPlayed == "Player1")
        {
            gameManager.GetComponent<GameManager>().initCoroutine("Freeze!", "p1");
            player2.GetComponent<Player2Movement>().initStopCoroutine(lastPlayed);
        }
        else
        {
            gameManager.GetComponent<GameManager>().initCoroutine("Freeze!", "p2");
            player1.GetComponent<Player1MovementScript>().initStopCoroutine(lastPlayed);
        }

        camera.GetComponent<PowerUpCreationScript>().currentPowerUps--;
        camera.GetComponent<PowerUpCreationScript>().initCoroutine();

        Destroy(gameObject);

    }

    public void turbo(string lastPlayed)
    {
        if (lastPlayed == "Player1")
        {
            gameManager.GetComponent<GameManager>().initCoroutine("Turbo!", "p1");
            player2.GetComponent<Player2Movement>().initTurboCoroutine(lastPlayed);
        }
        else
        {
            gameManager.GetComponent<GameManager>().initCoroutine("Turbo!", "p2");
            player1.GetComponent<Player1MovementScript>().initTurboCoroutine(lastPlayed);
        }

        camera.GetComponent<PowerUpCreationScript>().currentPowerUps--;
        Destroy(gameObject);


    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Ball")
        {
            string lastPlayed = ball.GetComponent<BallMovement>().lastPlayed;
            switch (chosenPower)
            {
                case 1:
                    freeze(lastPlayed);
                    break;
                case 2:
                    turbo(lastPlayed);
                    break;
            }

        }
    }
}
