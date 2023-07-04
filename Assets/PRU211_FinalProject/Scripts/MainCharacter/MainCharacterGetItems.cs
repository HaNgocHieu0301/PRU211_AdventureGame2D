using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterGetItems : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            
        }
    }
}
