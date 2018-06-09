using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public void LoadScene(string name)
    {
        Debug.Log("Loading scene " + name);
        SceneManager.LoadScene(name);
    }

    public void LoadScene(int index)
    {
        Debug.Log("Loading scene with index " + index);
        SceneManager.LoadScene(index);
    }

    public void Exit()
    {
        Debug.Log("Bye!");
        Application.Quit();
    }
}

