using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour{

    [Header("Configuracion")]
    [SerializeField] int points = 1;

    private void OnParticleCollision(GameObject other){

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.Modify_Life(points);
            Debug.Log(" PUNTOS DE DA�O REALIZADOS AL JUGADOR " + points);
        }

    }
}
