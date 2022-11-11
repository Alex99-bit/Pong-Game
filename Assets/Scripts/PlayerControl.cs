using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigidPlayer;
    Transform playerTransform;
    [SerializeField] float speed;
    float moveY;
    bool limiteSup, limiteInf;

    // Start is called before the first frame update
    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        moveY = 0;
        limiteInf = false;
        limiteSup = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            // Comienza a ejecuarse el codigo en caso de que ya se este jugando
            Movement();
            Limitless();
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W) && !limiteSup)
        {
            moveY = 0;
            moveY++;
            //moveY = 1;
            //Debug.Log("W pressed");
        }
        else if (Input.GetKey(KeyCode.S) && !limiteInf)
        {
            moveY = 0;
            moveY--;
            //moveY = -1;
            //Debug.Log("S pressed");
        }
        else
        {
            moveY = 0;
        }

        rigidPlayer.velocity = new Vector2(0, moveY * speed);
        
    }

    void Limitless()
    {
        // Calcula si topa con un limite o nel
        if (playerTransform.position.y >= 3.77f)
        {
            limiteSup = true;
        }
        else
        {
            limiteSup = false;
            if(playerTransform.position.y <= -5.04f)
            {

            }
        }
    }
}
