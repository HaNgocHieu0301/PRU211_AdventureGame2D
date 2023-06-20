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
        GameObject loadedGameObject = Resources.Load<GameObject>(StringHelper.LOAD_LEVEL_PATH + curLevel);
        if (loadedGameObject == null)
        {
            loadedGameObject = Resources.Load<GameObject>(StringHelper.LOAD_LEVEL_PATH + (curLevel-1));
        }
        GameObject level = Instantiate(loadedGameObject, levelObject.transform) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
