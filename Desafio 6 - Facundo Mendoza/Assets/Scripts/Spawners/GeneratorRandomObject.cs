using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorRandomObject : MonoBehaviour {

    [SerializeField] private GameObject[] objectsPrefabs;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float time_wait;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float time_intervale;

    /*
    void Start(){
        InvokeRepeating(nameof(GenerateRandomObject), time_wait, time_intervale);
    }
    */

    void GenerateRandomObject(){
        int index_Random = Random.Range(0, objectsPrefabs.Length);
        GameObject prefabRandom = objectsPrefabs[index_Random];
        Instantiate(prefabRandom, transform.position, Quaternion.identity);
    }

    private void OnBecameInvisible(){
        Debug.Log("El SpriteRenderer deja de ser visible por las cámaras en la escena");
        CancelInvoke(nameof(GenerateRandomObject));
    }

    private void OnBecameVisible(){
        Debug.Log("El SpriteRenderer es visible por las cámaras en la escena");
        InvokeRepeating(nameof(GenerateRandomObject), time_wait, time_intervale);
    }

}
