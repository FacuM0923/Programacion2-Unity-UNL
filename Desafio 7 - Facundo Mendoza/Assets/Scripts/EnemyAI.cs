using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    //Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocity = 5f;

    //Referencia al transform del jugador serializada
    [SerializeField] Transform Player;

    //Variable para referenciar otro componente del objeto
    private Rigidbody2D rb2D;
    private Vector2 direction;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        direction = (Player.position - transform.position).normalized;
        rb2D.MovePosition(rb2D.position + direction * (velocity * Time.fixedDeltaTime));
    }

}