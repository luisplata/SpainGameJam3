using System.Collections;
using System.Collections.Generic;
using Rest;
using UnityEngine;
using UnityEngine.Networking;

public class RestPost
{
    public delegate void RestPostOk<T>(T result);
    public delegate void RestPostBad<T>(T result);
    
    public static IEnumerator PostRest<T>(string url, RestPostOk<T> ok, RestPostBad<T> bad)
    {
        WWWForm form = new WWWForm();
        
        form.AddField("palabraSecreta", "");

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.downloadHandler.text);
                var convert = JsonUtility.FromJson<T>(www.downloadHandler.text);
                Debug.Log(www.error);
                Debug.Log(convert);
                bad?.Invoke(convert);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                var convert = JsonUtility.FromJson<T>(www.downloadHandler.text);
                ok(convert);
            }
        }
    }
}
