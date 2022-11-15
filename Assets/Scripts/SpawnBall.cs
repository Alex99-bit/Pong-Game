using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public static SpawnBall sharedInstance;
    public Transform spawn1, spawn2, ballTransform;
    public Rigidbody2D ballRigid;
    int gol;
    public float force,delay;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        spawn1 = GameObject.Find("SpawnBall1").GetComponent<Transform>();
        spawn2 = GameObject.Find("SpawnBall2").GetComponent<Transform>();
        ballTransform = GetComponent<Transform>();
        delay = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        //ballTransform = this.GetComponent<Transform>();
        ballRigid = this.GetComponent<Rigidbody2D>();
        //ballTransform = spawn1;
    }

    private void Update()
    {
        delay += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if(GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            if (GameManager.start)
            {
                // Este codigo se ejecuta unicamente en cuanto comienza el juego
                GameManager.start = false;
                print("start activado");
                this.transform.position = spawn1.position;
                if (delay >= 1.5f)
                {
                    delay = 0;
                    ballRigid.AddForce(Vector2.left * force, ForceMode2D.Impulse);
                    print("Activado despues del delay");
                }
            }

            if (delay >= 1.5f && gol != 0)
            {
                delay = 0;
                switch (gol)
                {
                    case 1:
                        gol = 0;
                        // El jugador 1 recibio un gol, por ende se le añade una fuerza a la pelota en su direccion
                        ballRigid.velocity = Vector2.zero;
                        ballRigid.AddForce(Vector2.left * force, ForceMode2D.Impulse);
                        break;
                    case 2:
                        gol = 0;
                        // El jugador 2 recibio un gol, por ende se le añade una fuerza a la pelota en su direccion
                        ballRigid.velocity = Vector2.zero;
                        ballRigid.AddForce(Vector2.right * force, ForceMode2D.Impulse);
                        break;
                    default:
                        // Si no pasa nada de eso, el gol se mantiene en 0
                        gol = 0;
                        break;
                }
            }


        }
    }

    // Creo que al final no sirvio
    /*public void Saque(int lado)
    {
        ballRigid.velocity = new Vector2(0,0);

        delay += Time.deltaTime;

        if (delay >= 1.5f)
        {
            // 1 a la izq, 2 a la der
            switch (lado)
            {
                case 1:
                    //this.transform.position = spawn1.position;
                    transform.position.Set(spawn1.position.x, spawn1.position.y, spawn1.position.z);
                    ballRigid.AddForce(Vector2.left * force, ForceMode2D.Impulse);
                    break;
                case 2:
                    //this.transform.position = spawn2.position;
                    transform.position.Set(spawn2.position.x, spawn2.position.y, spawn2.position.z);
                    ballRigid.AddForce(Vector2.right * force, ForceMode2D.Impulse);
                    break;
                default:
                    Debug.Log("Ese lado no existe aquí mi rey");
                    break;
            }
            delay = 0;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            // Detectar el gol
            if (collision.gameObject.CompareTag("Wall1"))
            {
                // Gol para player 2
                GameManager.sharedInstance.scorePlayer2++;
                gol = 1;
                this.transform.position = spawn1.position;
                // Saca el jugador 1, por ende se spawnea de su lado
                //ballTransform = spawn1;
            }

            if (collision.gameObject.CompareTag("Wall2"))
            {
                // Gol para player 1
                GameManager.sharedInstance.scorePlayer1++;
                gol = 2;
                this.transform.position = spawn2.position;
                // Saca el jugador 2, por ende se spawnea de su lado
                //ballTransform = spawn2;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player1") || collision.collider.CompareTag("Player2"))
        {
            GameManager.sharedInstance.timer = 0;
        }
    }
}
