using System;
using System.Collections;
using System.Collections.Generic;
using Rest;
using UnityEngine;

public class ControladorDeFinalEnvioDePostComienzoDeVideo : MonoBehaviour
{
    [SerializeField] private string endpoint;
    [SerializeField] private GetVideoFromUrl final, finalAlter;

    private void Start()
    {
        SendMessage();
    }

    public void SendMessage()
    {
        GuardarIntento();
    }
    
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
            if (float.Parse(porcent.value) >= 100)
            {
                StartCoroutine(PlayVideo(finalAlter));
            }
            else
            {
                StartCoroutine(PlayVideo(final));
            }
        }, () =>
        {
            //Error
        }));
    }

    IEnumerator PlayVideo(GetVideoFromUrl video)
    {
        while (!video.IsPrepared)
        {
            yield return new WaitForSeconds(0.3f);
        }
        video.StartVideo();
    }
    private void GuardarIntento()
    {
        //http://dev.sgj3.peryloth.com/api/getConf/palabraSecreta
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