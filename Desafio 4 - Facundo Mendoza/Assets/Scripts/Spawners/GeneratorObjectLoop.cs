using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObjectLoop : MonoBehaviour {

    [SerializeField] private GameObject objectPrefab;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float time_wait;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float time_intervale;

    void Start(){
        InvokeRepeating(nameof(GeneratorObjectLoop), time_wait, time_intervale);
    }

    void GenerateObjectLoop(){
        Instantiate(objectPrefab, transform.position, Quaternion.identity);
    }

}
