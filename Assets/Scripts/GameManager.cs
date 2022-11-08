using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager sharedInstance;
    public GameStates currentGameState;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Compara si esta en el juego y se pulsa el boton de pause
        if (Input.GetButton("Pause") && currentGameState == GameStates.pause)
        {

        }
    }

    // Quaternion.identity investigar que onda xd
    // Instantiate(pelota, transform.position, Quaternion.idenity);

    void SetNewGameState(GameStates newGameState)
    {

    }
}

public enum GameStates
{
    start,
    inGame,
    pause,
    gameOver,
    onePlayer,
    twoPlayer
}
