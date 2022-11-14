using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public Transform ballTransform, spawn1, spawn2;

    // Start is called before the first frame update
    void Start()
    {
        ballTransform = this.GetComponent<Transform>();
        spawn1 = GetComponent<Transform>();
        spawn2 = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detectar el gol

    }
}
