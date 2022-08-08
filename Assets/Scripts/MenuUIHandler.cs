using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject enemyNameText;
    public static string enemyName;
    // Start is called before the first frame update
    void Awake()
    {
        enemyNameText = GameObject.FindGameObjectWithTag("EnemyNameInput");
        if(enemyNameText != null)
        {
            var tMP_Input = enemyNameText.GetComponent<TMP_InputField>();
            tMP_Input.interactable = true;
            tMP_Input.text = MainManager.Instance.EnemyName;
        }
    }
    public void SetEnemyName(string s)
    {
        MainManager.Instance.EnemyName = s;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
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
