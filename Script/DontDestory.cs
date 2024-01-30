using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DontDestory : MonoBehaviour
{
    public static DontDestory _dontDestory;
    public int Sceenindex;
    private void Start()
    {
        if(_dontDestory == null)
        {
            _dontDestory = this;
        }
        else
        {
            _dontDestory = this;
        }
        DontDestroyOnLoad(this.gameObject);  
    }

    public void LoadLevel(int Level)
    {
        SceneManager.LoadScene(Level);
        MainPanel._Mainpanel.LevelPanel.SetActive(false);
        MainPanel._Mainpanel._Main.SetActive(false);
        MainPanel._Mainpanel._Push.SetActive(true);
        Sceenindex = Level;
        GameAudio.GameAudio_.Component(true);
        Time.timeScale = 1;   
    }

}
