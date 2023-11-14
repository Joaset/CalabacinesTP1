using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] private GameObject generatorCloud;
    [SerializeField] private float speedX;
    [SerializeField] private bool changeDirection;
    void Start()
    {
        speedX = 10f;
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
        Instantiate(generatorCloud,transform.position,transform.rotation);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("GenerateCloud");
    }
}
