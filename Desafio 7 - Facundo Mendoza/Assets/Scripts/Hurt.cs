using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour{

    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] int points = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){

            Player player = collision.gameObject.GetComponent<Player>();
            player.Modify_Life(-points);
            Debug.Log(" PUNTOS DE DAÑO REALIZADOS AL JUGADOR " + points);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

    }
}
