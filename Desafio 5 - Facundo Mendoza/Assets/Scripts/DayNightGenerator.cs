using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GeneradorDiaNoche : MonoBehaviour{

    [SerializeField] private Camera camara;
    [SerializeField] private Color nightColor;
    [SerializeField] private Light2D light2D;


    [SerializeField][Range(1, 128)] private int durationDay;
    [SerializeField][Range(1, 24)] private int days;

    private Color dayColor;


    void Start(){
        dayColor = camara.backgroundColor;
        StartCoroutine(ChangeColor(durationDay));
    }

    IEnumerator ChangeColor(float time){

        Color colorDestinyBack = camara.backgroundColor == dayColor ? nightColor : dayColor;
        Color colorDestinyLight = light2D.color != Color.white ? Color.white : nightColor;
        float durationCicle = time * 0.6f;
        float durationChange = time * 0.4f;

        for (int i = 0; i < days; i++){

            yield return new WaitForSeconds(durationCicle);

            float tiempoTranscurrido = 0;

            while (tiempoTranscurrido < durationChange){

                tiempoTranscurrido += Time.deltaTime;
                float t = tiempoTranscurrido / durationChange;

                float smoothT = Mathf.SmoothStep(0f, 1f, t);

                camara.backgroundColor = Color.Lerp(camara.backgroundColor, colorDestinyBack, smoothT);
                light2D.color = Color.Lerp(light2D.color, colorDestinyLight, smoothT);

                yield return null;
            }

            colorDestinyLight = light2D.color != Color.white ? Color.white : nightColor;
            colorDestinyBack = camara.backgroundColor == dayColor ? nightColor : dayColor;

        }
    }
}