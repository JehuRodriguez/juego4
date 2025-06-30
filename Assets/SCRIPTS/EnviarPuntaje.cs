using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class EnviarPuntaje : MonoBehaviour
{
    public InputField inputNombre;   
    public InputField inputPuntaje;

    public void AlPresionarBoton()
    {
        StartCoroutine(EnviarDatos());
    }

    IEnumerator EnviarDatos()
    {
        string nombreUsuario = inputNombre.text;
        int puntaje = int.Parse(inputPuntaje.text);

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
