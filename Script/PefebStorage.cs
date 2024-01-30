using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PefebStorage : MonoBehaviour
{
    public static PefebStorage Pefeb;
    public GameObject[] DatePefeb;
    private void Awake()
    {
        if(Pefeb == null)
        {
            Pefeb = this;
        }
        else
        {
            Pefeb = this;
        }
    }

    public GameObject PefebReturn(string Name)
    {
        foreach (GameObject item in DatePefeb)
        {
            if(item.gameObject.name == Name)
            {
                return item.gameObject;
            }
        }
        return null;
    }
}
