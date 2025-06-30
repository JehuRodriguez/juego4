using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
public class PuntajeActual : MonoBehaviour
{
    public TMP_InputField inputNombre;

    public void AlPresionarBoton()
    {
        string nombre = inputNombre.text;

        if (string.IsNullOrEmpty(nombre))
        {
            Debug.LogWarning("Ingrese un nombre para consultar su puntaje.");
            return;
        }

        StartCoroutine(ConsultarPuntaje(nombre));
    }

    IEnumerator ConsultarPuntaje(string nombre)
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre_usuario", nombre);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego4/obtener_puntaje.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(" Error al obtener el puntaje: " + www.error);
            }
            else
            {
                string resultado = www.downloadHandler.text.Trim();
                Debug.Log(" Puntaje actual de " + nombre + ": " + resultado);
            }
        }
    }
}
