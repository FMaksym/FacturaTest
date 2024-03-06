using UnityEngine;
using UnityEngine.SceneManagement;

public class ASyncLoader : MonoBehaviour
{
    [SerializeField] private string _loadSceneName;

    private void Start()
    {
        LoadGameASync();
    }

    private void LoadGameASync()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(_loadSceneName);
    }
}
