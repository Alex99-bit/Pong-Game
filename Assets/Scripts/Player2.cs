using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Transform posPelota;
    Rigidbody2D playerRb;
    float moveY;
    bool limiteSup, limiteInf;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Se busca el objeto ball y se extrae la posicion
        posPelota = GameObject.FindWithTag("Ball").GetComponent<Transform>();
        playerRb = GetComponent<Rigidbody2D>();
        moveY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameType == GameType.onePlayer &&
            GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            // Solo se ejecuta si se selecciono el modo de un jugador y se esta jugando
            this.transform.position = new Vector2(transform.position.x, posPelota.position.y);
            MovmentCPU();
            Limitless();
        }

        if (GameManager.sharedInstance.currentGameType == GameType.twoPlayer &&
                GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            // Se ejecuta en caso de que sean dos jugadores
            Movment();
            Limitless();
            Debug.Log("Esto se ejecuta weon");
        }
    }

    void MovmentCPU()
    {

    }

    void Movment()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !limiteSup)
        {
            moveY = 0;
            moveY++;
            //moveY = 1;
            //Debug.Log("W pressed");
            Debug.Log("arriba");
        }
        else if (Input.GetKey(KeyCode.DownArrow) && !limiteInf)
        {
            moveY = 0;
            moveY--;
            //moveY = -1;
            //Debug.Log("S pressed");
            Debug.Log("abajo");
        }
        else
        {
            moveY = 0;
        }

        playerRb.velocity = new Vector2(0, moveY * speed);
    }

    void Limitless()
    {
        // Calcula si topa con un limite o nel
        if (playerRb.position.y >= 3.7f)
        {
            limiteSup = true;
        }
        else
        {
            limiteSup = false;
        }

        if (playerRb.position.y <= -5.0f)
        {
            limiteInf = true;
        }
        else
        {
            limiteInf = false;
        }
    }
}
