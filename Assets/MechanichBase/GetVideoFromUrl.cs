using UnityEngine;
using UnityEngine.Video;
using Rest;

public class GetVideoFromUrl : MonoBehaviour
{
    public delegate void Respuesta(string url);
    [SerializeField] private string endpoint;
    [SerializeField] private string parametro;
    [SerializeField] private VideoPlayer video;
    [SerializeField] private bool isPreparedVideo;
    [SerializeField] private GameObject canvas;
    public bool IsPrepared => isPreparedVideo;
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
    private void ObtenerVideoDeCinematicaInicial(Respuesta respuesta)
    {
        StartCoroutine(RestGet.GetRequest($"{endpoint}/api/getConf/{parametro}", (ConfigurationGame infoGame) =>
        {
            Debug.Log($"Config {infoGame.nombre} value {infoGame.valor}");
            respuesta?.Invoke(infoGame.valor);
        }, () =>
        {
            Debug.Log("Error");
        }));
    }

    public void StartVideo()
    {
        video.Play();
        canvas.SetActive(true);
    }
}