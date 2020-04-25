using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public void OnClickResumeButton()
    {
        Time.timeScale = 1;
        AudioManager.Play(AudioClipName.Click);
        gameObject.SetActive(false);
    }
}
