using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("equisde");
        rb.velocity = new UnityEngine.Vector3(0, 1 * speed);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
