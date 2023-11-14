using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    void Start()
    {
        speed = 2f;
    }

    
    void Update()
    {
        transform.Translate(0,-speed * Time.deltaTime,0);
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
