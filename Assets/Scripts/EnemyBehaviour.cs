using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float countPoints;
    [SerializeField] private PointsCount points;
    private float speed;
    [SerializeField] private AudioClip enemySound;

    private void Start() {
        countPoints = -1f;
        speed = 4f;
        points = GameObject.FindGameObjectWithTag("puntos").GetComponent<PointsCount>();
    }

    void Update()
    {
        transform.Translate(0,-speed * Time.deltaTime,0);
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("player"))
        {
            SoundController.Instance.soundEjecution(enemySound);
            points.ScorePoints(countPoints);
            Destroy(gameObject);
        }
    }
}
