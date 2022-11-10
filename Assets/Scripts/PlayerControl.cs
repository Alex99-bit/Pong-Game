using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigidPlayer;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidPlayer = this.GetComponent<Rigidbody2D>();
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            // Comienza a ejecuarse el codigo en caso de que ya se este jugando

        }
    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            speed++;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            speed--;
        }

        rigidPlayer.velocity = new Vector2(0, speed);
    }
}
