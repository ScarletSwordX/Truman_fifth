using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{

    public bool Begin;
    public bool Scene15;
    public bool Scene67;


    // Start is called before the first frame update
    void Start()
    {
        if (Begin) VoiceManager.Instance.PlayStartBGM();
        else if (Scene15) VoiceManager.Instance.PlayBGM1();
        else if (Scene67) VoiceManager.Instance.PlayBGM2();
    }
}
