using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour{
    [Header("Configuracion")]
    [SerializeField] private float life = 5f;

    public void Modify_Life(float points){
        life += points;
        Debug.Log(Alive());
    }

    private bool Alive(){
        return life > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.CompareTag("Goal")){

            FindAnyObjectByType<Victory>().ShowVictory();

            Debug.Log("GANASTE");
            FindAnyObjectByType<Victory>().ShowVictory();

        }

        if (collision.gameObject.CompareTag("Traps")){

            FindAnyObjectByType<GameOver>().ShowGameOver();

            Debug.Log("GAME OVER");
            FindAnyObjectByType<GameOver>().ShowGameOver();

        }

    }
}