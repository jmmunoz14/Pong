using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public UnityEngine.Vector3 initialPosition;
    int startPlayerX;
    int startPlayerY;

    [SerializeField] private float speed;
    
    [SerializeField] private Rigidbody2D rb;

    bool firstFrame = true;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        setBall();
    }


    // Update is called once per frame
    void Update()
    {


    }

    public void setBall()
    {
        float dirX = Random.Range(-1.0f,1.0f);
        float dirY = Random.Range(-1.0f,1.0f);

        if(dirX >= 0)
        {
            startPlayerX = 1;
        }
        else{
            startPlayerX = -1;
        }

        if(dirY >= 0)
        {
            startPlayerY = 1;
        }
        else{
            startPlayerY = -1;
        }


        rb.velocity = new UnityEngine.Vector2(startPlayerX*speed,startPlayerY*speed);
    }

    public void Reset()
    {
        transform.position = initialPosition;
        rb.velocity = Vector2.zero;
        setBall();
    }

}
