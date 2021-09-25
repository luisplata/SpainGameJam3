using UnityEngine;
using UnityEngine.Video;
using Rest;

public class GetVideoFromUrl : MonoBehaviour
{
    public delegate void Respuesta(string url);
    [SerializeField] private string endpoint;
    [SerializeField] private string parametro;
    [SerializeField] private VideoPlayer video;
    public bool isPreparedVideo;
    [SerializeField] private GameObject canvas;
    private void Start()
    {
        //GuardarIntento();
        ObtenerVideoDeCinematicaInicial((string urlVideo) =>
        {
            video.source = VideoSource.Url;
            urlVideo = urlVideo.Replace('\\',char.MinValue);
            video.url = urlVideo;
            Debug.Log($"preparado {urlVideo}");
            video.prepareCompleted += source =>
            {
                isPreparedVideo = true;
                video.Pause();
            };
        });
    }

    public float GetTimeOfVideo()
    {
        double time = video.frameCount / video.frameRate;
        System.TimeSpan VideoUrlLength = System.TimeSpan.FromSeconds(time);
        var totalTime = VideoUrlLength.Seconds;
        totalTime += (VideoUrlLength.Minutes * 60);
        Debug.Log($"totalTime {totalTime}");
        return totalTime;
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
        canvas.SetActive(true);
        video.Play();
    }

    public void StopAll()
    {
        video.Stop();
        canvas.SetActive(false);
    }
}