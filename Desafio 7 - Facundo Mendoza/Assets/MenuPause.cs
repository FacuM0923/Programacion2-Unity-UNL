using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour {

    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    private bool juegoPausado = false;

    private void Update(){

        if (Input.GetKeyDown(KeyCode.P)){

            if (juegoPausado){
                Reanudar();
            }
            else{
                Pausa();
            }
        
        }
    
    }

    public void Pausa(){ 

        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    
    public void Reanudar(){

        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);

    }

    public void Reiniciar(){

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Cerrar(){

        Debug.Log("Cerrando el juego");
        Application.Quit();
    }

}
