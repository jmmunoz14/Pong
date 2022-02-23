using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCreationScript : MonoBehaviour
{

    public GameObject powerUp;

    [SerializeField] public int currentPowerUps = 0;

    [SerializeField] public int maxPowerUps = 2;

    // Start is called before the first frame update
    void Start()
    {
        initCoroutine();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void initCoroutine()
    {
        StartCoroutine(appearOnTheField());
    }

    IEnumerator appearOnTheField()
    {
        while (currentPowerUps < maxPowerUps)
        {
            Debug.Log(currentPowerUps);

            // execute block of code here
            yield return new WaitForSeconds(3f);

            float xAxis = UnityEngine.Random.Range(-10.0f, 10.0f);
            float yAxis = UnityEngine.Random.Range(-5.0f, 5.0f);

            Instantiate(powerUp, new Vector3(xAxis, yAxis, 0), Quaternion.identity);
            currentPowerUps++;
        }

    }
}
