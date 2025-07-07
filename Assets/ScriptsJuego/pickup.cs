using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public int valorPuntaje = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Recolector recolector = other.GetComponent<Recolector>();
            if (recolector != null)
            {
                recolector.SumarPuntaje(valorPuntaje);
            }

            Destroy(gameObject);
        }
    }
}
