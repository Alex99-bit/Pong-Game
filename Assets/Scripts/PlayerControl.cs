using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rigidPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
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

        }
    }
}
