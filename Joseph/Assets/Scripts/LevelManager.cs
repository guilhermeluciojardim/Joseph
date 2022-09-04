using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI panelText;
    [SerializeField] private GameObject player;
    public string panelString;

    private bool isMessageShowed = true;

    void Start(){
        
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
