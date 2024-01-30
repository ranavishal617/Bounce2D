using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeRingPanel : MonoBehaviour
{

    public Text _LifeText;
    public Text _RingText;

    private void Update()
    {
        if (Player.Player_.PlayerDie)
        {
            _LifeText.text = "X " + Player.Player_.Dead.ToString();
            _RingText.text = "X " + Player.Player_.RingCount.ToString();
        }
    }
}
