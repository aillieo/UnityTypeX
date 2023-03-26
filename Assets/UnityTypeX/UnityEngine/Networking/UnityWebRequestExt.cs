using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public static class UnityWebRequestExt
{
    public static UnityWebRequest PostJson(string url, string jsonData)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(jsonData);
        UnityWebRequest request = new UnityWebRequest(url, "POST", new DownloadHandlerBuffer(), new UploadHandlerRaw(bytes));
        request.SetRequestHeader("Content-Type", "application/json");
        return request;
    }
}
