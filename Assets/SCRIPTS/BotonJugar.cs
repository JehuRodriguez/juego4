using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Botonjugar : MonoBehaviour
{
    public TMP_InputField inputNombre;

    public void AlPresionarJugar()
    {
        string nombre = inputNombre.text;

        if (string.IsNullOrEmpty(nombre))
        {
            Debug.LogWarning("Debes ingresar un nombre antes de jugar.");
            return;
        }

        DatosJugador.nombre = nombre; 

        SceneManager.LoadScene("Juego");
    }
}
