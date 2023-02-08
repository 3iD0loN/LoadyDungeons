using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

// Used for the Hat selection logic
public class PlayerConfigurator : MonoBehaviour
{
	public AssetReference AssetReference;
	public string Address;
	[SerializeField]
	private Transform m_HatAnchor;
	private AsyncOperationHandle<GameObject> m_handle;


	private AsyncOperationHandle m_HatLoadingHandle;

	void Start()
	{
		Debug.LogFormat("Address: {0}", Address);

		//If the condition is met, then a hat has been unlocked
		if (GameManager.s_ActiveHat >= 0)
		{
			//SetHat(string.Format("Hat{0:00}", UnityEngine.Random.Range(0, 4)));

			// Fetch the correct hat variable from the ApplyRemoteConfigSettings instance
			//hatKey is an Addressable Label
			//Debug.Log("Hat String: " + string.Format("Hat{0:00}", UnityEngine.Random.Range(0, 4)));
		}
		SetHat(string.Format("Hat{0:00}", UnityEngine.Random.Range(0, 4)));
		// SetHat(Address);
	}

	public void SetHat(string hatKey)
	{
		Debug.Log(hatKey);
		m_handle = Addressables.InstantiateAsync(hatKey, m_HatAnchor);
	}

	// public void SetHat(string hatKey)
	// {
	// 	// AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(AssetReference);
	// 	AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(hatKey);
	// 	asyncOperationHandle.Completed += HatOperationHandle_Completed;
	// }

	// private void HatOperationHandle_Completed(AsyncOperationHandle<GameObject> asyncOperationHandle)
	// {
	// 	Debug.Log("AsyncOperationHandle Status: " + asyncOperationHandle.Status);
	// }

	private void OnDisable()
	{
		m_HatLoadingHandle.Completed -= OnHatInstantiated;
		Addressables.ReleaseInstance(m_handle);
	}

	private void OnHatInstantiated(AsyncOperationHandle obj)
	{
		// We can check for the status of the InstantiationAsync operation: Failed, Succeeded or None
		if (obj.Status == AsyncOperationStatus.Succeeded)
		{
			Debug.Log("Hat instantiated successfully");
		}

		m_HatLoadingHandle.Completed -= OnHatInstantiated;
	}
}
