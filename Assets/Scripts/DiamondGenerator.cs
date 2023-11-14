using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondGenerator : MonoBehaviour
{
    [SerializeField] private GameObject generatorDiamond;
    [SerializeField] private float speedX;
    [SerializeField] private bool changeDirection;
    private float randomTime;
    void Start()
    {
        speedX = 5f;
        changeDirection = true;
        StartCoroutine("GenerateCloud");

    }

    void Update()
    {
        
        if(changeDirection == true)
        {
            transform.Translate(speedX * Time.deltaTime, 0, 0);
            if (transform.position.x >= 8.44f)
            {
                changeDirection = false;
            }
        }

        if (changeDirection == false)
        {
            transform.Translate(-speedX * Time.deltaTime, 0, 0);
            if(transform.position.x <= -8.44f)
            {
                changeDirection = true;
            }
        }
    }

    IEnumerator GenerateCloud()
    {
        Instantiate(generatorDiamond,transform.position,transform.rotation);
        randomTime = Random.Range(1, 3);
        yield return new WaitForSeconds(randomTime);
        StartCoroutine("GenerateCloud");
    }
}
