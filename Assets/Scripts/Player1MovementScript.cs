using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class Player1MovementScript : MonoBehaviour
{

    [SerializeField] private float speed;
    private Player1 player1;

    public UnityEngine.Vector3 initialPosition;

    private void Awake() {
        player1 = new Player1();
    }

    private void OnEnable() {
        player1.Enable();
    }

    private void OnDisable() {
        player1.Disable();
    }

    private void Start() {
        initialPosition = transform.position;
    }

    private void Update() {
        float movementInput = player1.Player.Move.ReadValue<float>();
        UnityEngine.Vector3 currentPosition =  transform.position;
        currentPosition.y += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;
    }

    public void Reset()
    {
        transform.position = initialPosition;
    }
}
