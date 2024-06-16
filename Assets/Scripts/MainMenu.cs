using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
    }

    public void QuitMaze()
    {
        // This will not work in the Unity editor
        Application.Quit();

        // Add a debug log message to confirm the button press in the editor
        Debug.Log("Quit Game");
    }
}
