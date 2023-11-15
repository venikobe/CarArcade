using UnityEngine;

public class SetTargetFrameRate : MonoBehaviour 
{
	[SerializeField] private int targetFrameRate = 24;

	private void Start()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = targetFrameRate;
	}
}
