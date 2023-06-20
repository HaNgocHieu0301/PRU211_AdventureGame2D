using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISampleScene : MonoBehaviour
{
    public Button RestartButton;
    // Start is called before the first frame update
    void Start()
    {
        RestartButton.onClick.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        
    }
}
