using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI controlsText;
    private void Start()
    {
       
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Controls(){
        if (controlsText.isActiveAndEnabled){
            controlsText.gameObject.SetActive(false);
        }
        else{
            controlsText.gameObject.SetActive(true);
        }
        
    }
    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }    
}
