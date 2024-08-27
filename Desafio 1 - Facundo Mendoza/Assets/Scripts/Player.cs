using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (!collision.gameObject.CompareTag("Meta")) { return; }
        Debug.Log("GANASTE");
    }
}