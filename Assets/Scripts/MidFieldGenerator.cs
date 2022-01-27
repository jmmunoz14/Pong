using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MidFieldGenerator : MonoBehaviour
{

    public GameObject midLine;

    // Start is called before the first frame update
    void Start()
    {
        
        Camera cam = Camera.main;
        float verticalSize = Convert.ToSingle(Camera.main.orthographicSize);
        
        while (verticalSize > 0){
            float spaceHeight = midLine.GetComponent<SpriteRenderer>().bounds.size.y;
            Instantiate(midLine, new Vector3(0, verticalSize, 0), Quaternion.identity);
            Instantiate(midLine, new Vector3(0, -verticalSize, 0), Quaternion.identity);

            verticalSize = verticalSize - (1.3f*spaceHeight);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
