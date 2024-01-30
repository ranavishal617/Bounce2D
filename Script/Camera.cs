using UnityEngine;

public class Camera : MonoBehaviour
{

    public static Camera _Camera;

    public GameObject _Canvas;
    private bool ON_Off;
    public Vector3 offset = new Vector3(0,0,-10);
    public bool Cameraoff;

    private void Start()
    {
        if(DontDestory._dontDestory.Sceenindex == 0)
        {
            DontDestory._dontDestory.Sceenindex = 1;
        }
        if (_Camera == null)
        {
            _Camera = this;
        }
        else
        {
            _Camera = this;
        }
        Cameraoff = true;
        ON_Off = true;
        GameAudio.GameAudio_.Component(true);
    }


    private void LateUpdate()
    {
        if (Player.Player_ != null)
        {
            ON_Off = true;
        }
        else
        {
            ON_Off = false;
        }
        if (ON_Off)
        {
            transform.position = follwCamera(ON_Off);
        }
    }

    private Vector3 follwCamera(bool on_off)
    {
        transform.position = new Vector3(Player.Player_.gameObject.transform.position.x, 0, 0) + offset;

        if (Player.Player_.gameObject.gameObject.transform.position.y > 4)
        {
            transform.position = new Vector3(Player.Player_.gameObject.transform.position.x, Player.Player_.gameObject.transform.position.y, 0) + offset;
        }

        if (Player.Player_.gameObject.transform.position.y < -4)
        {
            transform.position = new Vector3(Player.Player_.gameObject.transform.position.x, Player.Player_.gameObject.transform.position.y, 0) + offset;
        }

        if(on_off)
        {
            return transform.position;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
