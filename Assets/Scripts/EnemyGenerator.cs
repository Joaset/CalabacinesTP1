using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject generatorMonster;
    [SerializeField] private GameObject generatorSkull;
    [SerializeField] private float speedX;
    [SerializeField] private bool changeDirection;
    private float enemyType;
    private float randomTime;
    void Start()
    {
        speedX = 5f;
        changeDirection = true;
        StartCoroutine("GenerateEnemy");

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

    IEnumerator GenerateEnemy()
    {
        enemyType = Random.Range(1,3);
        if (enemyType == 1)
        {
            Instantiate(generatorMonster,transform.position,transform.rotation);
            randomTime = Random.Range(1, 3);
            yield return new WaitForSeconds(randomTime);
            StartCoroutine("GenerateEnemy");
        }
        else if (enemyType == 2)
        {
            Instantiate(generatorSkull,transform.position,transform.rotation);
            randomTime = Random.Range(1, 3);
            yield return new WaitForSeconds(randomTime);
            StartCoroutine("GenerateEnemy");
        }
    }
}
