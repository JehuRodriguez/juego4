using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] pickups;
    public float tiempoEntreRondas = 5f;
    public int[] pickupsPorRonda = { 2, 4, 5, 6, 8 }; 
    public float tiempoMaximo = 60f;

    private float tiempoPasado = 0f;
    private int ronda = 0;
    private bool spawneando = true;


    void Start()
    {
        StartCoroutine(SpawnRondas());
    }


    IEnumerator SpawnRondas()
    {
        while (spawneando)
        {
            if (tiempoPasado >= tiempoMaximo)
            {
                spawneando = false;
                Debug.Log("¡Tiempo terminado! Ya no se generan pickups.");
                yield break;
            }

            int cantidad = pickupsPorRonda[Mathf.Min(ronda, pickupsPorRonda.Length - 1)];
            for (int i = 0; i < cantidad; i++)
            {
                Vector3 pos = new Vector3(Random.Range(-8f, 8f), 1f, Random.Range(-8f, 8f));
                int index = Random.Range(0, pickups.Length);
                Instantiate(pickups[index], pos, Quaternion.identity);
            }

            ronda++;
            yield return new WaitForSeconds(tiempoEntreRondas);
            tiempoPasado += tiempoEntreRondas;
        }

        spawneando = false;
        Debug.Log("¡Tiempo terminado! Enviando puntaje...");
        FindObjectOfType<EnviarPuntajeDesdeJuego>().Enviar();

    }

}
