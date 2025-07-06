using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MostrarNombre : MonoBehaviour
{
    public TextMeshProUGUI textoNombre;

    void Start()
    {
        textoNombre.text = DatosJugador.nombre;
    }
}
