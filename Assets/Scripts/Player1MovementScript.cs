using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class Player1MovementScript : MonoBehaviour
{

    [SerializeField] public float speed;
    private Player1 player1;

    public UnityEngine.Vector3 initialPosition;

    private void Awake()
    {
        player1 = new Player1();
    }

    private void OnEnable()
    {
        player1.Enable();
    }

    private void OnDisable()
    {
        player1.Disable();
    }

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float movementInput = player1.Player.Move.ReadValue<float>();
        UnityEngine.Vector3 currentPosition = transform.position;
        currentPosition.y += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;
    }

    public void Reset()
    {
        transform.position = initialPosition;
    }

    IEnumerator stopMovement(string lastPlayed)
    {

        float tempSpeed = speed;
        speed = 0;
        Debug.Log("speed 0");
        yield return new WaitForSeconds(2f);
        Debug.Log("speed " + tempSpeed);

        speed = tempSpeed;

    }


    public void initStopCoroutine(string lastPlayed)
    {
        StartCoroutine(stopMovement(lastPlayed));

    }


    IEnumerator turboMovement(string lastPlayed)
    {

        float tempSpeed = speed;
        speed = speed * 2;
        // execute block of code here
        yield return new WaitForSeconds(5f);
        speed = tempSpeed;

    }


    public void initTurboCoroutine(string lastPlayed)
    {
        StartCoroutine(turboMovement(lastPlayed));
    }
}
