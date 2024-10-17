using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObject : MonoBehaviour {

    [SerializeField] private GameObject objectPrefab;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float time_wait;

    void Start(){

        Invoke("GenerateObject", time_wait);

    }

    // Update is called once per frame
    void GenerateObject(){

        Instantiate(objectPrefab, transform.position, Quaternion.identity);
        
    }
}
