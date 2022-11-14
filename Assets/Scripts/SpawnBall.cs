using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] Transform ballTransform, spawn1, spawn2;
    Rigidbody2D ballRigid;
    int gol;

    private void Awake()
    {
        spawn1 = GameObject.Find("SpawnBall1").GetComponent<Transform>();
        spawn2 = GameObject.Find("SpawnBall2").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ballTransform = this.GetComponent<Transform>();
        ballRigid = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            switch (gol)
            {
                case 1:
                    gol = 0;
                    // El jugador 1 recibio un gol, por ende se le añade una fuerza a la pelota en su direccion

                    break;
                case 2:
                    gol = 0;
                    // El jugador 2 recibio un gol, por ende se le añade una fuerza a la pelota en su direccion

                    break;
                default:
                    // Si no pasa nada de eso, el gol se mantiene en 0
                    gol = 0;
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            // Detectar el gol
            if (collision.gameObject.CompareTag("Wall1"))
            {
                // Gol para player 2
                GameManager.scorePlayer2++;
                gol = 1;
                // Saca el jugador 1, por ende se spawnea de su lado
                ballTransform = spawn1;
            }

            if (collision.gameObject.CompareTag("Wall2"))
            {
                // Gol para player 1
                GameManager.scorePlayer1++;
                gol = 2;
                // Saca el jugador 2, por ende se spawnea de su lado
                ballTransform = spawn2;
            }
        }
    }
}
