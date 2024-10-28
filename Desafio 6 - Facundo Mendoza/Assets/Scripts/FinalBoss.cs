using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour {

    [SerializeField] float timeBetweenShoots;
    [SerializeField] float timeBetweenCharges;
    [SerializeField] float timeBetweenMovements;

    [SerializeField] GameObject prefabProjectile;
    [SerializeField] Transform spawnPointProjectile;

    private float actualTimeWait;
    private int actualState;

    //Estados del jefe
    private const int ShootProjectile = 0;
    private const int Attack = 1;
    private const int Move = 2;

    void Start(){
        actualState = ShootProjectile;
        StartCoroutine(BehaviorBoss());
    }

    private IEnumerator BehaviorBoss(){

        while (true){
            switch (actualState){

                case ShootProjectile:
                    StartCoroutine(Shoot());
                    actualTimeWait = timeBetweenShoots;
                    break;
                case Attack:
                    StartCoroutine(Charge());
                    actualTimeWait = timeBetweenCharges;
                    break;
                case Move:
                    StartCoroutine(Movement());
                    actualTimeWait = timeBetweenMovements;
                    break;
            }

            Debug.Log(actualState);
            yield return new WaitForSeconds(actualTimeWait);
            UpdateState();
        }
    }

    private IEnumerator Shoot(){
        for (int i = 0; i < 5; i++){
            yield return new WaitForSeconds(0.5f);
            Instantiate(prefabProjectile, spawnPointProjectile.position, Quaternion.identity);
        }
    }

    private IEnumerator Charge(){
        float timeAttack = 2f;
        float timeStart = Time.time;
        float velocityCharge = -8f; //Ajusta la velocidad de la embestida según tus necesidades

        Vector2 initialPosition = transform.position;
        Vector2 targetPosition = new Vector2(transform.position.x + velocityCharge, transform.position.y);

        //Mover hacia adelante
        while (Time.time < timeStart + timeAttack / 2){
            transform.position = Vector2.Lerp(initialPosition, targetPosition, (Time.time - timeStart) / (timeAttack / 2));
            yield return null;
        }

        //Mover hacia atrás (retroceso)
        timeStart = Time.time;
        while (Time.time < timeStart + timeAttack / 2){
            transform.position = Vector2.Lerp(targetPosition, initialPosition, (Time.time - timeStart) / (timeAttack / 2));
            yield return null;
        }
    }

    private IEnumerator Movement(){

        float timeMovement = 3f; //Ajusta la duración del movimiento según tus necesidades
        float timeStart = Time.time;
        float velocityMovement = 6f;

        Vector2 initialPosition = transform.position;
        Vector2 targetPosition = new Vector2(transform.position.x, transform.position.y + velocityMovement);

        //Mover hacia la posición objetivo
        while (Time.time < timeStart + timeMovement / 2){
            transform.position = Vector2.Lerp(initialPosition, targetPosition, (Time.time - timeStart) / (timeMovement / 2));
            yield return null;
        }

        //Mover hacia la posición inicial
        timeStart = Time.time;
        while (Time.time < timeStart + timeMovement / 2){
            transform.position = Vector2.Lerp(targetPosition, initialPosition, (Time.time - timeStart) / (timeMovement / 2));
            yield return null;
        }
    }

    private void UpdateState() {
        // Actualiza el estado actual según las probabilidades y condiciones que desees
        // Puedes usar Random.Range para generar números aleatorios y decidir el siguiente estado
        actualState = Random.Range(0, 3);
    }
}