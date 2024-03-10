using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlButton : MonoBehaviour
{
    public void OpenUrl()
    {
        Application.OpenURL("https://www.gene.com/topics/hematology");
        Debug.Log("hello");
    }
}
