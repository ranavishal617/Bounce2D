using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class Gate : MonoBehaviour
{

    public int SceenIndex;
    public int Num;

    private void Start()
    {  
        DontDestory._dontDestory.Sceenindex = SceneManager.GetActiveScene().buildIndex;
    }
    void Update()
    {
        if(Player.Player_.RingCount <= 0)
        {
            Win();
        }
    }
    public void Win()
    {
        if (PlayerPrefs.GetInt("MyName") <= Num)
        {
            PlayerPrefs.SetInt("MyName", Num + 1);
        }
        Instantiate(PefebStorage.Pefeb.PefebReturn("Gate2"), transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
