using UnityEngine;

public class GravityPower : MonoBehaviour
{
    public float Time;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.name = "Gravity";
    }

    private void OnCollisionEnter2D(Collision2D co)
    {
        if (co.gameObject.tag == "Player")
        {
            Player.Player_.Gravity = Time;
        }
    }
}
