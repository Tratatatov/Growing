using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    public void NextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    private void Start()
    {
        if (EventBus.Instance != null)
            EventBus.Instance.OnFinished.AddListener(NextLevel);
    }

}
