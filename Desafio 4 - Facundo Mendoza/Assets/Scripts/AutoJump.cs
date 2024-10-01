using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJump : MonoBehaviour {
    //Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] private float strength_jump = 5f;

    private Rigidbody2D rb2D;

    //Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable(){
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        rb2D.AddForce(Vector2.up * strength_jump, ForceMode2D.Impulse);
    }
}
