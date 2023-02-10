using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
	private AsyncOperationHandle m_SceneHandle;

	[SerializeField]
	private Slider m_LoadingSlider;

	[SerializeField]
	private GameObject m_PlayButton, m_LoadingText;

	void OnEnable()
	{
		DownloadSceneDependencies();
	}

	private void OnDisable()
	{
		Addressables.Release(m_SceneHandle);
	}

	private void DownloadSceneDependencies()
	{
		m_SceneHandle = Addressables.DownloadDependenciesAsync("Level_0" + GameManager.s_CurrentLevel);
		m_SceneHandle.Completed += M_SceneHandle_Completed;
	}

	private void M_SceneHandle_Completed(AsyncOperationHandle asyncOperationHandle)
	{
		m_LoadingSlider.value = 1;
		m_PlayButton.SetActive(true);
		Debug.Log("Succeeded");
	}

	private void Update()
	{
		if (!m_SceneHandle.IsDone)
		{
			m_LoadingSlider.value = m_SceneHandle.GetDownloadStatus().Percent;
		}
	}

	public void GoToNextLevel()
	{
		Addressables.LoadSceneAsync("Level_0" + GameManager.s_CurrentLevel);
	}
}
