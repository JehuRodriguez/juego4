using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAlJuego : MonoBehaviour
{
    public TMP_InputField inputNombre;

    public void Jugar()
    {
        string nombreIngresado = inputNombre.text;

        if (string.IsNullOrEmpty(nombreIngresado))
        {
            Debug.LogWarning("Debes ingresar un nombre");
            return;
        }
        DatosJugador.nombre = nombreIngresado; 
        SceneManager.LoadScene("Juego");      

    }
}
