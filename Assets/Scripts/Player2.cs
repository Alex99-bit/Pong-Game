using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Transform posPelota;

    // Start is called before the first frame update
    void Start()
    {
        // Se busca el objeto ball y se extrae la posicion
        posPelota = GameObject.FindWithTag("Ball").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameStates.onePlayer &&
            GameManager.sharedInstance.currentGameState == GameStates.inGame)
        {
            // Solo se ejecuta si se selecciono el modo de un jugador y se esta jugando
            this.transform.position = new Vector2(transform.position.x, posPelota.position.y);

        }
        else
        {
            if(GameManager.sharedInstance.currentGameState == GameStates.twoPlayer &&
                GameManager.sharedInstance.currentGameState == GameStates.inGame)
            {
                // Se ejecuta en caso de que sean dos jugadores

            }
        }
    }
}
