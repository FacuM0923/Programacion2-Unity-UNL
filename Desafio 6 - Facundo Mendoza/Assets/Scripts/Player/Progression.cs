using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour {

    private Player jugador;

    private void Awake(){
        jugador = GetComponent<Player>();
    }

    public void GanarExperiencia(int nuevaExperiencia)
    {
        jugador.PerfilJugador.Experiencia += nuevaExperiencia;

        if (jugador.PerfilJugador.Experiencia >= jugador.PerfilJugador.Experiencia)
        {
            SubirNivel();
        }
    }

    private void SubirNivel()
    {
        jugador.PerfilJugador.Nivel++;
        jugador.PerfilJugador.Experiencia -= jugador.PerfilJugador.ExperienciaProximoNivel;
        jugador.PerfilJugador.ExperienciaProximoNivel += jugador.PerfilJugador.EscalarExperiencia;
    }
}