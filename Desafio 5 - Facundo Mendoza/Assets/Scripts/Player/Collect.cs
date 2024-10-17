using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

    [SerializeField] private List<GameObject> colleccionables;
    [SerializeField] private GameObject bolsa;

    private bool presionado = false;

    private void Awake(){
        colleccionables = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if(!collision.gameObject.CompareTag("Coleccionable")) { return;  }

        GameObject newColeccionable = collision.gameObject;
        newColeccionable.SetActive(false);

        colleccionables.Add(newColeccionable);
        newColeccionable.transform.SetParent(bolsa.transform);
    
    }

    private void Update(){

        if (Input.GetKeyDown(KeyCode.F1)){

            if (colleccionables.Count == 0) return;

            presionado = !presionado;
            colleccionables[0].SetActive(presionado);

        }

    }
}
