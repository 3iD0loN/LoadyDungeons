using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Slider m_LoadingSlider;

    [SerializeField]
    private GameObject m_PlayButton, m_LoadingText;
    private AsyncOperationHandle m_SceneHandle;

    void OnEnable()
    {
        StartCoroutine(DownloadSceneDependencies());
    }

    private IEnumerator DownloadSceneDependencies()
    {
        m_SceneHandle = Addressables.DownloadDependenciesAsync("Level_0" + GameManager.s_CurrentLevel);

        while (!m_SceneHandle.IsDone)
        {
            m_LoadingSlider.value = m_SceneHandle.GetDownloadStatus().Percent;
            yield return null;
        }

        m_LoadingSlider.value = 1;
        m_PlayButton.SetActive(true);
        Debug.Log("Succeeded");
    }

    // Function to handle which level is loaded next
    public void GoToNextLevel()
    {
        Addressables.LoadSceneAsync("Level_0" + GameManager.s_CurrentLevel);
    }
}
