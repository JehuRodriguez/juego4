using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class ObtenerRanking : MonoBehaviour
{
    public TextMeshProUGUI rankingTexto;

    void Start()
    {
        StartCoroutine(ConsultarRanking());
    }

    IEnumerator ConsultarRanking()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/juego4/obtener_ranking.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error: " + www.error);
            }
            else
            {
                rankingTexto.text = www.downloadHandler.text;
            }
        }
    }
}
