using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static pickup;

public class Recolector : MonoBehaviour
{
    public int puntaje = 0;
    public TextMeshProUGUI puntajeTexto;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            int valor = other.GetComponent<pickup>().valorPuntaje;
            puntaje += valor;
            Debug.Log("Recolectado: +" + valor + " puntos");
            Destroy(other.gameObject);
        }
    }

    void ActualizarTexto()
    {
        puntajeTexto.text = "Puntaje: " + puntaje;
    }

}
