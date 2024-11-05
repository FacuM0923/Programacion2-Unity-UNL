using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour{
    
    public void Jugar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }

    // Update is called once per frame
    public void Salir(){
        Debug.Log("Salir...");
        Application.Quit();
    }
}
