using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Text mesh pro

public class GameManager : MonoBehaviour
{
    static public GameManager sharedInstance;
    public GameStates currentGameState;
    [SerializeField]TextMeshProUGUI scoreP1, scoreP2;// Textos para mostrar el score
    [SerializeField]int scorePlayer1, scorePlayer2; // Score para contabilizar

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
        scoreP1.text = "0";
        scoreP2.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Compara si esta en el juego y se pulsa el boton de pause
        if (Input.GetButton("Pause") && currentGameState == GameStates.inGame)
        {
            // Se pone el estado en pausa
            SetNewGameState(GameStates.pause);
        }else if(Input.GetButton("Pause") && currentGameState == GameStates.pause)
        {
            // Entonces se debería quitar la pausa
            SetNewGameState(GameStates.inGame);
        }
    }

    // Quaternion.identity investigar que onda xd
    // Instantiate(pelota, transform.position, Quaternion.idenity);

    void SetNewGameState(GameStates newGameState)
    {
        // Aqui se administra que pasa en cada estado
        switch (newGameState)
        {
            case GameStates.start:
                Time.timeScale = 0;
                break;
            case GameStates.pause:
                Time.timeScale = 0;
                break;
            case GameStates.inGame:
                Time.timeScale = 1;
                break;
            case GameStates.gameOver:
                Time.timeScale = 0;
                break;
            default:
                Debug.Log("Error: Si ves este texto entonces valio m****s");
                break;
        }

        sharedInstance.currentGameState = newGameState;
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
