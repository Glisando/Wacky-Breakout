using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void OnClickQuitButton()
    {
        AudioManager.Play(AudioClipName.Click);

        Application.Quit();
    }
}
