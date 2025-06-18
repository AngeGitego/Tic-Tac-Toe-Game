using TMPro;
using UnityEngine;

public class PlatformInfo : MonoBehaviour
{
    public TMP_Text platformText;

    void Start()
    {
#if UNITY_STANDALONE_WIN
        platformText.text = "Running on Windows";
#elif UNITY_STANDALONE_OSX
        platformText.text = "Running on macOS";
#elif UNITY_STANDALONE_LINUX
        platformText.text = "Running on Linux";
#else
        platformText.text = "Running on Unknown Platform";
#endif
    }
}
