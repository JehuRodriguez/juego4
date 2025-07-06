using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MostrarNombre : MonoBehaviour
{
    public TextMeshPro textoNombre;

    void Start()
    {
        textoNombre.text = DatosJugador.nombre;
    }
}
