#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Steamworks;
using System;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private static MainMenuManager instance;

    [SerializeField] private GameObject menuScreen, lobbyScreen;
    [SerializeField] private TMP_InputField lobbyInput;
    [SerializeField] private TextMeshProUGUI lobbyTitle, lobbyIDText;
    [SerializeField] private Button startGameButton;

    private void Awake() => instance = this;


    private void Start()
    {
        OpenMainMenu();
    }

    public void StartMatch(string sceneName)
    {
        CloseAllScreens();
        SceneManager.LoadScene(sceneName);
    }

    public void CreateLobby()
    {
        BootstrapManager.CreateLobby();
        CloseAllScreens();

    }

    public static void LobbyEntered(string lobbyName, bool isHost)
    {
        instance.lobbyTitle.text = lobbyName;
        instance.startGameButton.gameObject.SetActive(isHost);
        instance.lobbyIDText.text = BootstrapManager.CurrentLobbyID.ToString();
        instance.OpenLobby();
    }

    void CloseAllScreens()
    {
        menuScreen.SetActive(false);
        lobbyScreen.SetActive(false);
    }

    public void OpenMainMenu()
    {
        CloseAllScreens();
        menuScreen.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1)
    }

    public void OpenLobby()
    {
        CloseAllScreens();
        lobbyScreen.SetActive(true);
    }

    public void JoinLobby()
    {
        CSteamID steamID = new CSteamID(Convert.ToUInt64(lobbyInput.text));
        BootstrapManager.JoinByID(steamID);
    }

    public void LeaveLobby()
    {
        BootstrapManager.LeaveLobby();
        OpenMainMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }
}
