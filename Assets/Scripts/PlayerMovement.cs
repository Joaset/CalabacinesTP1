using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float inputMovement;
    private float limitX;
    //private float limitY;
    void Start()
    {
        speed = 5f;
        limitX = 8.44f;
        //limitY = 4.15F;
    }

    
    void Update()
    {
        Move();
        Flip();
    }

    void Move()
    {
        inputMovement = Input.GetAxis("Horizontal");

        if (gameObject.transform.position.x < -limitX)
        {
            gameObject.transform.position = new Vector3(-limitX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if (gameObject.transform.position.x > limitX)
        {
            gameObject.transform.position = new Vector3(limitX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            transform.Translate(inputMovement * speed * Time.deltaTime, 0, 0);
        }
        
    }


    void Flip()
    {
        if (inputMovement < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (inputMovement > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
