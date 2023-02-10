using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

// Used for the Hat selection logic
public class PlayerConfigurator : MonoBehaviour
{
	[SerializeField]
	private Transform m_HatAnchor;
	private AsyncOperationHandle<GameObject> m_handle;

	void Start()
	{
		SetHat(string.Format("Hat{0:00}", UnityEngine.Random.Range(0, 4)));
	}

	public void SetHat(string hatKey)
	{
		Debug.Log(hatKey);
		m_handle = Addressables.InstantiateAsync(hatKey, m_HatAnchor);
	}

	private void OnDisable()
	{
		Addressables.ReleaseInstance(m_handle);
	}
}
