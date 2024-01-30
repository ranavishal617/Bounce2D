using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deth : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject,0.1f);
    }
}
