using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GeneradorDiaNoche : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Color nightColor;
    [SerializeField] private Light2D light2D;


    [SerializeField][Range(1, 128)] private int durationDay;
    [SerializeField][Range(1, 24)] private int days;

    private Color dayColor;


    void Start(){
        dayColor = camera.backgroundColor;
        StartCoroutine(ChangeColor(durationDay));
    }

    IEnumerator ChangeColor(float time){

        Color colorDestinyBack = camera.backgroundColor == dayColor ? nightColor : dayColor;
        Color colorDestinyLight = light2D.color != Color.white ? Color.white : nightColor;
        float durationCycle = time * 0.6f;
        float durationChange = time * 0.4f;

        for (int i = 0; i < days; i++) {
            
            yield return new WaitForSeconds(durationCycle);
            float timeRemained = 0;

            while (timeRemained < durationChange){
                timeRemained += Time.deltaTime;
                float t = timeRemained / durationChange;

                float smoothT = Mathf.SmoothStep(0f, 1f, t);

                camera.backgroundColor = Color.Lerp(camera.backgroundColor, colorDestinyBack, smoothT);
                light2D.color = Color.Lerp(light2D.color, colorDestinyLight, smoothT);

                yield return null;
            }

            colorDestinyLight = light2D.color != Color.white ? Color.white : nightColor;
            colorDestinyBack = camera.backgroundColor == dayColor ? nightColor : dayColor;

        }
    }
}