using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public Slider sliderDifficulty;

    void Update()
    {
        //Debug.Log(PlayerPrefs.GetFloat("DIFF"));
    }


    public void difficulty()
    {
        PlayerPrefs.SetFloat("DIFF", sliderDifficulty.value);
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetFloat("DIFF"));
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
