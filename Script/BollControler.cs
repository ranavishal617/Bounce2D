using UnityEngine;
using UnityEngine.SceneManagement;


    // Eunm For Enemy
public enum Move
{
    Enemy_Up_Down,
    Enemy_Right_Left
}

public static class BollControler
{
    // CheckPoint_Methods && Win Gate_Method Code
    #region CheckPoint_Work



    private static Vector3 Pos = Player.Player_.transform.position;

    private static Vector3 BollSiez = Player.Player_.transform.localScale;

    public static void SavePosition(Vector3 Check_pos)
    {
        BollSiez = Player.Player_.transform.localScale;
        Pos = Check_pos;
    }

    public static void BackPosition()
    {
        Player.Player_.Dead--;
        Player.Player_.transform.position = Pos;
        Player.Player_.transform.localScale = BollSiez;
    }

    public static void MegaSiez()
    {
        Player.Player_.transform.localScale = new Vector3(0.36f, 0.36f, 0.36f);
    }

    public static void MegaSmall()
    {
        Player.Player_.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }

    #endregion

    #region WinWork
    public static void LevelWin()
    {
        Physics2D.gravity = new Vector2(0f, -9.31f);
        if (SceneManager.GetActiveScene().buildIndex <= MainPanel._Mainpanel._Levels_Buttons.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }    
    }

    

    #endregion
}
