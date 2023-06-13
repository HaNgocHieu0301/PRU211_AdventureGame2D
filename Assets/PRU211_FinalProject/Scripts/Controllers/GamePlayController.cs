using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public GameObject levelObject;
    
    // Start is called before the first frame update
    private void Awake()
    {
        int curLevel = PlayerPrefs.GetInt("curLevel", 0);
        GameObject level = Instantiate(Resources.Load<GameObject>(StringHelper.LOAD_LEVEL_PATH + curLevel), levelObject.transform) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
