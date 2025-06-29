using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ObtenerPuntaje : MonoBehaviour
{
    public string nombreUsuario = "Ana";

    void Start()
    {
        StartCoroutine(ConsultarPuntaje());
    }


    IEnumerator ConsultarPuntaje()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombre_usuario", nombreUsuario);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/juego4/obtener_puntaje.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error: " + www.error);
            }
            else
            {
                Debug.Log("Puntaje actual: " + www.downloadHandler.text);
            }
        }
    }
}
