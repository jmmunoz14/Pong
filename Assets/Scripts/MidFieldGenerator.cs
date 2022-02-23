using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MidFieldGenerator : MonoBehaviour
{

    public GameObject midLine;

    public GameObject powerUp;


    // Start is called before the first frame update
    void Start()
    {

        Camera cam = Camera.main;
        float verticalSize = Convert.ToSingle(Camera.main.orthographicSize);

        while (verticalSize > 0)
        {
            float spaceHeight = midLine.GetComponent<SpriteRenderer>().bounds.size.y;
            Instantiate(midLine, new Vector3(0, verticalSize, 0), Quaternion.identity);
            Instantiate(midLine, new Vector3(0, -verticalSize, 0), Quaternion.identity);

            verticalSize = verticalSize - (1.3f * spaceHeight);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator appearOnTheField()
    {
        // execute block of code here
        yield return new WaitForSeconds(3f);
        Debug.Log("appearOnTheField");

        float xAxis = UnityEngine.Random.Range(-10.0f, 10.0f);
        float yAxis = UnityEngine.Random.Range(-5.0f, 5.0f);

        Instantiate(powerUp, new Vector3(xAxis, yAxis, 0), Quaternion.identity);


    }
}
