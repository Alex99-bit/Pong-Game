using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Text mesh pro

public class GameManager : MonoBehaviour
{
    static public GameManager sharedInstance;
    public GameStates currentGameState;
    public GameType currentGameType;
    [SerializeField]TextMeshProUGUI scoreP1, scoreP2;// Textos para mostrar el score
    public static int scorePlayer1, scorePlayer2; // Score para contabilizar
    /* El score es estatico para poder administrarlo en otros scripts y que siempre mantenga su valor,
        al tener una instancia compartida, es más facil acceder a este dato */
    public static bool start;
    public GameObject panelStart, panelPause, panelGameOver;

    private void Awake()
    {
        Time.timeScale = 0;
        currentGameType = GameType.none;
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        start = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        scoreP1.text = "Player 1 : 0";
        scoreP2.text = "Player 2 : 0";
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

        if(currentGameState == GameStates.inGame)
        {
            scoreP1.text = "Player 1 : " + scorePlayer1;
            scoreP2.text = "Player 2 : " + scorePlayer2;
        }
    }

    public void StartGameOne()
    {
        SetNewGameState(GameStates.inGame);
        currentGameType = GameType.onePlayer;
        start = true;
        panelStart.active = false;
    }

    public void StartGameTwo()
    {
        SetNewGameState(GameStates.inGame);
        currentGameType = GameType.twoPlayer;
        start = true;
        panelStart.active = false;
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
                scorePlayer1 = 0;
                scorePlayer2 = 0;
                break;

            case GameStates.pause:
                Time.timeScale = 0;
                break;

            case GameStates.inGame:
                Time.timeScale = 1;
                break;

            case GameStates.gameOver:
                Time.timeScale = 0;
                scorePlayer1 = 0;
                scorePlayer2 = 0;
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
    gameOver
}

public enum GameType
{
    onePlayer,
    twoPlayer,
    none
}
