using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocity = 5f;

    //Variables de uso interno en el script
    private float horizontal_movement;
    private Vector2 direction;

    //Variable para referenciar otro componente del objeto
    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer sprite;
    private CircleCollider2D collider2D;
    private int jumpMask;

    //Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable(){

        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<CircleCollider2D>();
        jumpMask = LayerMask.GetMask("Floors", "Platforms");
    }

    //Código ejecutado en cada frame del juego (Intervalo variable)
    private void Update() {

        horizontal_movement = Input.GetAxis("Horizontal");
        direction = new Vector2(horizontal_movement, 0f);

        int velocityX = (int)rb2D.velocity.x;
        sprite.flipX = velocityX > 0;
        animator.SetInteger("Velocity", velocityX);

        animator.SetBool("InAir", !InContactWithPlatform());

    }

    private void FixedUpdate(){

        rb2D.AddForce(direction * velocity);

    }

    private bool InContactWithPlatform(){
        return collider2D.IsTouchingLayers(jumpMask);
    }

}
