using System;
using System.Collections;
using System.Collections.Generic;
using Rest;
using UnityEngine;

public class ControladorDeFinalEnvioDePostComienzoDeVideo : MonoBehaviour
{
    [SerializeField] private string endpoint;
    [SerializeField] private GetVideoFromUrl final, finalAlter;
    public delegate void RespuestaVideo();

    private void Post(string palabraSecreta)
    {
        StartCoroutine(RestPost.PostRest($"{endpoint}/api/saveData/{palabraSecreta}", (ResponseGame infoGame) =>
        {
            Debug.Log($"Result {infoGame.status}");
            //obtenemos el porcentaje
            GetPercentAndPlayVideo();
        }, (ResponseGame errorGame) =>
        {
            Debug.Log($"Error {errorGame.status}");
        }));
    }

    private void GetPercentAndPlayVideo()
    {
        StartCoroutine(RestGet.GetRequest($"{endpoint}/api/getdata", (PorcentOfGenerator porcent) =>
        {
            Debug.Log($"porcent {porcent.value}");
            StartCoroutine(PlayVideo(final, () =>
            {
                if (float.Parse(porcent.value) >= 100)
                {
                    StartCoroutine(PlayVideo(finalAlter, () =>
                    {
                        //Lo que debe hacer cuando termina el video
                    }));
                }
            }));
            
        }, () =>
        {
            //Error
        }));
    }

    IEnumerator PlayVideo(GetVideoFromUrl video)
    {
        while (!video.isPreparedVideo)
        {
            yield return new WaitForSeconds(0.3f);
        }
        video.StartVideo();
    }
    IEnumerator PlayVideo(GetVideoFromUrl video,RespuestaVideo callback)
    {
        while (!video.isPreparedVideo)
        {
            yield return new WaitForSeconds(0.3f);
        }
        video.StartVideo();
        yield return new WaitForSeconds(video.GetTimeOfVideo());
        video.StopAll();
        callback?.Invoke();
    }
    //Este es la funcion que dedes ejecutar para colocar el video del final y mandar la senal al servidor
    public void GuardarIntento()
    {
        StartCoroutine(RestGet.GetRequest($"{endpoint}/api/getConf/palabraSecreta", (ConfigurationGame infoGame) =>
        {
            Debug.Log($"Config {infoGame.nombre} value {infoGame.valor}");
            Post(infoGame.valor);
        }, () =>
        {
            Debug.Log("Error");
        }));
    }
}