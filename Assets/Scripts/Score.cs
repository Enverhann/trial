using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private GameManager gameManager;
    private int pointValue = 1;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {//Update score with trigger.
        if (other.CompareTag("Pickups"))
        {
            gameManager.UpdateScore(pointValue);
            Destroy(other.gameObject);
        }
    }
}
