using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    public static MainPanel _Mainpanel;
    void Start()
    {
        if (_Mainpanel == null)
        {
            _Mainpanel = this;
        }
        else
        {
            _Mainpanel = this;
        }

        NumBer = PlayerPrefs.GetInt("MyName");

        Time.timeScale = 0;
        
        for (int i = 0; i < NumBer; i++)
        {
            _Levels_Buttons[i].SetActive(true);
        }

        LevelSave(NumBer);

    }

    public void LoadSceen(int num)
    {
        SceneManager.LoadScene(num);
        Play();
        Time.timeScale = 1;
    }

    #region LevelPanel
    public GameObject LevelPanel;
    public int NumBer;
    public GameObject[] _Levels_Buttons;

    public void Level()
    {
        LevelPanel.SetActive(true);
        _Main.SetActive(false);
    }
    public void LevelBack()
    {
        LevelPanel.SetActive(false);
        _Main.SetActive(true);
    }
    public void LevelSave(int num)
    {
        _Levels_Buttons[num].SetActive(true);
    }

    public void LevelExit()
    {
        _Main.SetActive(true);
        _PanelSound.SetActive(false);
        _LevelButtonExit.SetActive(false);
        _Cancel.SetActive(false);
        _Back.SetActive(true);
        _Resume.SetActive(false);
        GameAudio.GameAudio_.Component(false);
    }

    #endregion


    // --------------

    #region UiPanels
    public GameObject _Main;
    public GameObject _PanelSound;
    public GameObject _Push;
    public GameObject _Back;
    public GameObject _Cancel;
    public GameObject _LevelPanel;
    public GameObject _LevelButtonExit;
    public GameObject _Resume;
    public GameObject _GameOver_Panel;
    public GameObject _Game_Complete;

    public bool Yes_No = true;

    // Start is called before the first frame update
   

    public void Back()
    {
        _Main.SetActive(true);
        _PanelSound.SetActive(false);
    }

    public void Push()
    {    
        PushWork();
    }

    public void Sound()
    {
        SoundButton();
    }

    public void Cancel()
    {
        CancelWork();
    }

    public void Play()
    {
        PlayButtonWork();
    }

    // -----------

    private void PushWork()
    {
        _Back.SetActive(false);
        _PanelSound.SetActive(true);
        _Cancel.SetActive(true);
        _PanelSound.SetActive(true);
        _Main.SetActive(false);
        _Push.SetActive(false);
        _LevelButtonExit.SetActive(true);
        _Resume.SetActive(true);
        Camera._Camera._Canvas.SetActive(false);
        Time.timeScale = 0;
        AdMob._admob.LoadAd();
    }

    private void CancelWork()
    {
        _PanelSound.SetActive(false);
        _Main.SetActive(false);
        _Push.SetActive(true);
        Camera._Camera._Canvas.SetActive(true);
        Time.timeScale = 1;
        AdMob._admob.DestroyBannerView();
    }

    private void SoundButton()
    {
        _PanelSound.SetActive(true);
    }

    private void PlayButtonWork()
    {
        _Main.SetActive(false);
        _Push.SetActive(true);
        _LevelPanel.SetActive(false);
        AdMob._admob.DestroyBannerView();
    }

    public void Resume()
    {
        _PanelSound.SetActive(false);
        _Push.SetActive(true);
        Camera._Camera._Canvas.SetActive(true);
        AdMob._admob.DestroyBannerView();
        Time.timeScale = 1;
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        _GameOver_Panel.SetActive(false);
        _Main.SetActive(true);
        Player.Player_.Dead = 3;
        DontDestory._dontDestory.Sceenindex = 0;
    }

    public void Restart()
    {
        _GameOver_Panel.SetActive(false);
        DontDestory._dontDestory.LoadLevel(DontDestory._dontDestory.Sceenindex);
        Time.timeScale = 1;
    }

    public void HomePanel()
    {
        _Game_Complete.gameObject.SetActive(false);
        _Main.SetActive(true);
    }

    #endregion
}
