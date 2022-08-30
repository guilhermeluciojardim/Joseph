using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI panelText;
    public string panelString;

    private bool isMessageShowed;

    void Start(){
        panelString = "You feel in the cistern and must find your way out \n Use the Arrow Keys to move \n PRESS ENTER TO CONTINUE...";
    }
    void Update(){
        if (!isMessageShowed){
            ShowText(panelString);
        }
    }

    public void ShowText(string text)
    {
        panelString=text;
        isMessageShowed=false;
        panel.SetActive(true);
        panelText.text = (text);
        Time.timeScale=0;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            panel.SetActive(false);
            Time.timeScale=1;
            isMessageShowed=true;
        }
        
    }
}
