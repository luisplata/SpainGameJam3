using System;
using System.Collections;
using System.Collections.Generic;
using Rest;
using UnityEngine;
using UnityEngine.Video;


public class ControladorDeCinematica : MonoBehaviour
{
    public delegate void Respuesta(string url);
    [SerializeField] private string endpoint;
    [SerializeField] private VideoPlayer video;
    [SerializeField] private bool isPreparedVideo;
    [SerializeField] private GameObject canvas;
    private void Start()
    {
        //GuardarIntento();
        ObtenerVideoDeCinematicaInicial((string urlVideo) =>
        {
            video.source = VideoSource.Url;
            video.url = urlVideo;
            video.prepareCompleted += source =>
            {
                isPreparedVideo = true;
                video.Pause();
            };
        });
    }

    public void StartVideo()
    {
        video.Play();
        canvas.SetActive(true);
    }

    private void ObtenerVideoDeCinematicaInicial(Respuesta respuesta)
    {
        StartCoroutine(RestGet.GetRequest($"{endpoint}/api/getConf/url_cinematica_inicial", (ConfigurationGame infoGame) =>
        {
            Debug.Log($"Config {infoGame.nombre} value {infoGame.valor}");
            respuesta?.Invoke(infoGame.valor);
        }, () =>
        {
            Debug.Log("Error");
        }));
    }

    private void ObtenerVideoDeCinematica()
    {
        StartCoroutine(RestGet.GetRequest($"{endpoint}/api/getConf/cinematicaFinal", (ConfigurationGame infoGame) =>
        {
            Debug.Log($"Config {infoGame.nombre} value {infoGame.valor}");
            Post(infoGame.valor);
        }, () =>
        {
            Debug.Log("Error");
        }));
    }
    
    private void ObtenerVideoDeCinematicaFinalAlternativo()
    {
        StartCoroutine(RestGet.GetRequest($"{endpoint}/api/getConf/cinematicaFinalAlternativo", (ConfigurationGame infoGame) =>
        {
            Debug.Log($"Config {infoGame.nombre} value {infoGame.valor}");
            Post(infoGame.valor);
        }, () =>
        {
            Debug.Log("Error");
        }));
    }

    private void Post(string palabraSecreta)
    {
        StartCoroutine(RestPost.PostRest($"{endpoint}/api/saveData/{palabraSecreta}", (ResponseGame infoGame) =>
        {
            Debug.Log($"Result {infoGame.status}");
        }, (ResponseGame errorGame) =>
        {
            Debug.Log($"Error {errorGame.status}");
        }));
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