using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMenuManager : MonoBehaviour
{

    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMainScene()
    {
        InstanceManager.instance.playerName = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        InstanceManager.instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
