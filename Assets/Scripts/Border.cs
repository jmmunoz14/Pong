using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public bool p1Border;
    public GameObject gameManager;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Ball")
        {
            if(p1Border){
                gameManager.GetComponent<GameManager>().P2Scored();
            }
            else{
                gameManager.GetComponent<GameManager>().P1Scored();
            }
        }
    }
}
