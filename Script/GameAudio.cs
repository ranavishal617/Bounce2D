using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAudio : MonoBehaviour
{
    public static GameAudio GameAudio_;
    


    
    #region Variables
    public AudioSource Play;
    public Slider slider;

    public AudioClip[] Music_List;
    #endregion
    private void Awake()
    {
        if(GameAudio_ == null)
        {
            GameAudio_ = this;
        }
        else
        {
            GameAudio_ = this;
        }
    }
    void Start()
    {   
        
        Play = GetComponent<AudioSource>();
        foreach (AudioClip item in Music_List)
        {
            if(item.name == "Background")
            {
                Play.clip = item;
                Play.loop = true;
            }
        }
        slider.value = PlayerPrefs.GetFloat("Sound");
    }

    private void Update()
    {
        Play.volume = slider.value;
        PlayerPrefs.SetFloat("Sound", Play.volume);
    }

    public void PlayShot(string Name)
    {
        foreach (AudioClip item in Music_List)
        {
            if(item.name == Name)
            {
                Play.PlayOneShot(item);
            }
        }
    }

    public void Component(bool Input)
    {
        if(Input == true)
        {
            Play.Play();
        }
        if(Input == false)
        {
            Play.Pause();
        }
    }
}
