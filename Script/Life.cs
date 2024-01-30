using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Life : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D co)
    {
        if(co.gameObject.CompareTag("Player"))
        {
            Player.Player_.PowerUp(1);
            GameAudio.GameAudio_.PlayShot("CheckPoint");
            Destroy(this.gameObject);
        }
    }
}
