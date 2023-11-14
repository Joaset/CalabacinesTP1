using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsCount : MonoBehaviour
{
    private float points;
    private TextMeshProUGUI textMesh;
    private bool canDead;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject character;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        canDead = false;
    }

    void Update()
    {
        textMesh.text = points.ToString("0");
    }

    public void ScorePoints(float enterPoints)
    {
        canDead = true;
        points += enterPoints;

        if(points <= 0 && canDead == true)
        {
            points = 0;
            Destroy(character);
            gameOver.SetActive(true);
        }

    }
}
