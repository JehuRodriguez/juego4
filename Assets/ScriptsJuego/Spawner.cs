using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] pickups;
    public Transform jugador;
    public float tiempoEntreRondas = 5f;
    public int[] pickupsPorRonda = { 2, 4, 5, 6, 8 }; 
    public float tiempoMaximo = 30f;

    private int ronda = 0;
    private bool spawneando = true;
    private float tiempoInicio;


    void Start()
    {
        Debug.Log("Spawner activo");
        tiempoInicio = Time.time;
        StartCoroutine(SpawnRondas());
    }


    IEnumerator SpawnRondas()
    {
        while (spawneando)
        {
            float tiempoActual = Time.time - tiempoInicio;

            if (tiempoActual >= tiempoMaximo)
            {
                spawneando = false;
                Debug.Log("¡Tiempo terminado! Ya no se generan pickups.");
                yield break;
            }

            int cantidad = pickupsPorRonda[Mathf.Min(ronda, pickupsPorRonda.Length - 1)];
            for (int i = 0; i < cantidad; i++)
            {
                Vector3 pos = jugador.position + new Vector3(Random.Range(-4f, 4f), 1f, Random.Range(-4f, 4f));
                int index = Random.Range(0, pickups.Length);
                GameObject clon = Instantiate(pickups[index], pos, Quaternion.identity);
                Debug.Log("Instanciado en: " + pos + " - Nombre: " + clon.name);
            }

            ronda++;
            yield return new WaitForSeconds(tiempoEntreRondas);
        }

        Debug.Log("¡Tiempo terminado! Enviando puntaje...");
        FindObjectOfType<EnviarPuntajeDesdeJuego>().Enviar();

    }

}
