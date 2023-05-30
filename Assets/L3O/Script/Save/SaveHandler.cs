using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    private void Start()
    {
        SaveAndLoad.instance.LoadFile();
    }
}

