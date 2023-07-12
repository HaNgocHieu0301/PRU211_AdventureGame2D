using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public GameObject levelObject;

    private Test_CameraFollow _cameraFollowScript;

    private Spawner _spawnerScript;

    private void Start()
    {
        int curLevel = PlayerPrefs.GetInt("curLevel", 0);
        GameObject loadedGameObject = Resources.Load<GameObject>(StringHelper.LOAD_LEVEL_PATH + curLevel);
        if (loadedGameObject == null)
        {
            loadedGameObject = Resources.Load<GameObject>(StringHelper.LOAD_LEVEL_PATH + (curLevel-1));
        }
        GameObject level = Instantiate(loadedGameObject, levelObject.transform);
        _spawnerScript = FindObjectOfType<Spawner>();
        _spawnerScript.Init();
        _cameraFollowScript = FindObjectOfType<Test_CameraFollow>();
        _cameraFollowScript.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
