using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate2 : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D co)
    {
        if(co.gameObject.tag == "Player")
        {
            Player.Player_.Gravity = 0;
            if(SceneManager.GetActiveScene().buildIndex == 10)
            {
                MainPanel._Mainpanel._Game_Complete.SetActive(true);
            }
            BollControler.LevelWin();
        }
    }
}
