using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Button startButton;
    public Button exitButton;
    public TextMeshProUGUI displayName;


    // Start is called before the first frame update
    void Start()
    {
        displayName = GameObject.Find("Name").GetComponent<TextMeshProUGUI>();
        nameInput = GameObject.Find("InputName").GetComponent<TMP_InputField>();
        startButton = GameObject.Find("Start Button").GetComponent<Button>();
        exitButton = GameObject.Find("Exit Button").GetComponent<Button>();
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
        if (Player.player.sharedName != null)
        {
            nameInput.text = Player.player.sharedName;
            displayName.text = Player.player.sharedName;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Player.player.sharedName = nameInput.text;
        displayName.text = Player.player.sharedName;
        Player.player.LoadHighScore();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
