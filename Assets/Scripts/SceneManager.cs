using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private InputSystem_Actions inputActions;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        inputActions.UI.Enable();
        inputActions.Player.Disable();
    }

    void OnDisable()
    {
        inputActions.UI.Disable();
        inputActions.Player.Enable();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        inputActions.UI.Disable();
        inputActions.Player.Disable();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void EndGame()
    {
        inputActions.UI.Disable();
        inputActions.Player.Disable();
        Application.Quit();
    }

    public void RestartGame()
    {
        inputActions.UI.Disable();
        inputActions.Player.Disable();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void ReturnToMainMenu()
    {
        inputActions.UI.Disable();
        inputActions.Player.Disable();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
