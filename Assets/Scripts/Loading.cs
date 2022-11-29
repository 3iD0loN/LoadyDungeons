using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private ResourceRequest m_SceneResourceRequest;
    private AsyncOperation m_SceneOperation;

    [SerializeField]
    private Slider m_LoadingSlider;

    [SerializeField]
    private GameObject m_PlayButton, m_LoadingText;

    private void OnEnable()
    {
        m_SceneResourceRequest = Resources.LoadAsync("Level_0" + GameManager.s_CurrentLevel);
        m_SceneResourceRequest.completed += OnSceneResourceLoaded;
    }

    private void OnSceneResourceLoaded(AsyncOperation asyncOperation)
    {
        m_SceneResourceRequest.completed -= OnSceneResourceLoaded;
    }

    private void OnDisable()
    {
        
    }

    private void OnSceneLoaded(AsyncOperation asyncOperation)
    {
        m_PlayButton.SetActive(true);
        m_SceneOperation.completed -= OnSceneLoaded;
    }

    // Function to handle which level is loaded next
    public void GoToNextLevel()
    {
        m_SceneOperation = SceneManager.LoadSceneAsync("Level_0" + GameManager.s_CurrentLevel);
        m_SceneOperation.completed += OnSceneLoaded;
    }

    private void Update()
    {
        // We don't need to check for this value every single frame, and certainly not after the scene has been loaded
        m_LoadingSlider.value = m_SceneResourceRequest.progress;
    }
}
