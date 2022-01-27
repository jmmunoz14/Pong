using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class Player2Movement : MonoBehaviour
{

    [SerializeField] private float speed;

    private Player2 player2;

    public UnityEngine.Vector3 initialPosition;

    private void Awake() {
        player2 = new Player2();

    }

    private void OnEnable() {
        player2.Enable();

    }

    private void OnDisable() {
        player2.Disable();
    }

    private void Start() {
        initialPosition = transform.position;
    }

    private void Update() {

        float movementInputP2 = player2.Player.Move.ReadValue<float>();
        UnityEngine.Vector3 currentPositionP2 =  transform.position;
        currentPositionP2.y += movementInputP2 * speed * Time.deltaTime;
        transform.position = currentPositionP2;

    }

    public void Reset()
    {
        transform.position = initialPosition;
    }
}
