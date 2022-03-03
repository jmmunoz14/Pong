using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class Player2Movement : MonoBehaviour
{

    [SerializeField] public float speed;

    private Player2 player2;

    public UnityEngine.Vector3 initialPosition;

    public GameObject ball;

    private UnityEngine.Vector2 ballPosition;

    public bool isRealPlayer;

    private bool stopped = false;


    private void Awake()
    {
        player2 = new Player2();

    }

    private void OnEnable()
    {
        player2.Enable();

    }

    private void OnDisable()
    {
        player2.Disable();
    }

    void chaseBall(){
        ballPosition = ball.transform.position;
    	
        float speedAdition = UnityEngine.Random.Range(0f,2f);
        if(stopped){
            speedAdition = 0;
        }

        
        if(transform.position.y > ballPosition.y){
            transform.position = transform.position + new UnityEngine.Vector3(0,-(speed+speedAdition)*Time.deltaTime,0);
        }

        if(transform.position.y < ballPosition.y){
            transform.position = transform.position + new UnityEngine.Vector3(0,(speed+speedAdition)*Time.deltaTime,0);
        }
    }
    

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {

        if(isRealPlayer){
            float movementInputP2 = player2.Player.Move.ReadValue<float>();
            UnityEngine.Vector3 currentPositionP2 = transform.position;
            currentPositionP2.y += movementInputP2 * speed * Time.deltaTime;
            transform.position = currentPositionP2;
        }
        else{
            chaseBall();
        }


    }


    IEnumerator stopMovement(string lastPlayed)
    {

        float tempSpeed = speed;
        speed = 0;
        stopped = true;
        // execute block of code here
        Debug.Log("speed 0");
        yield return new WaitForSeconds(2f);
        Debug.Log("speed " + tempSpeed);

        speed = tempSpeed;
        stopped = false;
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


    public void initStopCoroutine(string lastPlayed)
    {
        StartCoroutine(stopMovement(lastPlayed));

    }

    public void Reset()
    {
        transform.position = initialPosition;
    }
}
