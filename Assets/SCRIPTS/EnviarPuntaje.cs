using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;


public class EnviarPuntaje : MonoBehaviour
{
    public TMP_InputField inputNombre;
    public TMP_InputField inputPuntaje;

    public void AlPresionarBoton()
    {
        string nombreUsuario = inputNombre.text; 
        string puntajeTexto = inputPuntaje.text;

        if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(puntajeTexto))
        {
            Debug.LogWarning("Debe ingresar un nombre y un puntaje antes de enviar.");
            return;
        }

        if (!int.TryParse(puntajeTexto, out int puntaje))
        {
            Debug.LogWarning(" El puntaje debe ser un número válido.");
            return;
        }


        StartCoroutine(EnviarDatos(nombreUsuario, puntaje));
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
                Debug.Log("Respuesta del servidor: " + www.downloadHandler.text);
            }
        }
    }
}
