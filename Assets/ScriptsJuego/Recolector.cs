using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Recolector : MonoBehaviour
{
    public int puntaje = 0;
    public TextMeshProUGUI puntajeTexto;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            puntaje += 10;
            ActualizarTexto();
        }
    }

    void ActualizarTexto()
    {
        puntajeTexto.text = "Puntaje: " + puntaje;
    }

}
