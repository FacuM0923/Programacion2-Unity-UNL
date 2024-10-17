using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

    [SerializeField] private GameObject bolsa;
    [SerializeField] private Transform padreObjetivos;

    private Queue<GameObject> objetivos;

    private bool presionado = false;

    private void Awake(){
        
        objetivos = new Queue<GameObject>();
        CargarObjetivos();

    }

    private void CargarObjetivos(){

        foreach(Transform objetivo in padreObjetivos){

            objetivos.Enqueue(objetivo.gameObject);

        }

    }

    private void VerObjetivos(){

        foreach(GameObject objetivo in objetivos){
            Debug.Log(objetivo.name);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(!collision.gameObject.CompareTag("Coleccionable")) { return; }

        GameObject newColeccionable = collision.gameObject;
        newColeccionable.SetActive(false);

        newColeccionable.transform.SetParent(bolsa.transform);

    }

    private void Update(){

        if (Input.GetKeyDown(KeyCode.F1)){

            if (objetivos.Count == 0) return;

            presionado = !presionado;
        }
        
    }
}