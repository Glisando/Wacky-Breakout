using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("Play");
    }
}
