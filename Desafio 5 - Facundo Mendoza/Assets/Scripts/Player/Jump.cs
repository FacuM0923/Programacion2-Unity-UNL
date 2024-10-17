using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    //Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] private float strength_jump = 5f;

    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip collisionSFX;

    //Variables de uso interno en el script
    private bool can_jump = true;
    private bool jumping = false;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D rb2D;
    private AudioSource audio;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable(){
        rb2D = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    //Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update(){

        if (Input.GetKeyDown(KeyCode.Space) && can_jump){
            can_jump = false;

            if (audio.isPlaying) { return; }
            audio.PlayOneShot(jumpSFX);

        }
    }

    private void FixedUpdate(){

        if (!can_jump && !jumping){

            rb2D.AddForce(Vector2.up * strength_jump, ForceMode2D.Impulse);
            jumping = true;

        }
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision){
        can_jump = true;
        jumping = false;

        if (audio.isPlaying){ return; }
        audio.PlayOneShot(collisionSFX);

    }
}
