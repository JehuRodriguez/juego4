using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class EnviarPuntajeDesdeJuego : MonoBehaviour
{
    public Recolector recolector;

    public void Enviar()
    {
        string nombre = DatosJugador.nombre;
        int puntaje = recolector.puntaje;

        if (string.IsNullOrEmpty(nombre))
        {
            Debug.Log("Nombre vacío.");
            return;
        }

        StartCoroutine(EnviarDatos(nombre, puntaje));
    }

    IEnumerator EnviarDatos(string nombreUsuario, int puntaje)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre_usuario", nombreUsuario);
        form.AddField("puntaje", puntaje);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego4/insertar_actualizar_usuario.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error: " + www.error);
            }
            else
            {
                Debug.Log("Puntaje enviado: " + www.downloadHandler.text);
            }
        }
    }

}
