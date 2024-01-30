using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using System;

public enum RingSiez
{
    Small,
    Big
}

public class Ring : MonoBehaviour
{
    public RingSiez siez;
    public GameObject RingImg;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(rb.mass == 1)
        {
            siez = RingSiez.Small;
        }
        if (rb.mass == 2)
        {
            siez = RingSiez.Big;
        }
    }

    private void OnTriggerEnter2D(Collider2D co)
    {
        if(siez == Player.Player_._retune)
        {
            if (co.gameObject.CompareTag("Player"))
            {
                Player.Player_.Ring(1);
                GameAudio.GameAudio_.PlayShot("Ring");
                Instantiate(RingImg, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        } 
    }
}