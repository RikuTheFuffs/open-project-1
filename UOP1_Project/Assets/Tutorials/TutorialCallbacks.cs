using UnityEngine;
using Unity.InteractiveTutorials;

namespace AwesomeGame.Tutorials
{
	/// <summary>
	/// Implement your Tutorial callbacks here.
	/// </summary>
	[CreateAssetMenu(fileName = DefaultFileName, menuName = "Tutorials/" + DefaultFileName + " Instance")]
	public class TutorialCallbacks : ScriptableObject
	{
		public const string DefaultFileName = "TutorialCallbacks";
		public FutureObjectReference futureCameraSystemInstance = default;
		public FutureObjectReference futureSpawnSystemInstance = default;
		GameObject CameraSystemInstance { get { return futureCameraSystemInstance.sceneObjectReference.ReferencedObjectAsGameObject; } }
		GameObject SpawnSystemInstance { get { return futureSpawnSystemInstance.sceneObjectReference.ReferencedObjectAsGameObject; } }

		public static ScriptableObject CreateInstance()
		{
			return ScriptableObjectUtils.CreateAsset<TutorialCallbacks>(DefaultFileName);
		}

		// Example callbacks for ArbitraryCriterion's BoolCallback
		public bool HasCameraBeenAssignedToSpawn()
		{
			if (!SpawnSystemInstance || !CameraSystemInstance) { return false; }
			SpawnSystem spawnSystem = SpawnSystemInstance.GetComponent<SpawnSystem>();
			return spawnSystem.CameraManager != null && spawnSystem.CameraManager.gameObject == CameraSystemInstance;
		}

		// Implement the logic to automatically complete the criterion here, if wanted/needed.
		public bool AutoComplete()
		{
			var foo = GameObject.Find("Foo");
			if (!foo)
				foo = new GameObject("Foo");
			return foo != null;
		}
	}
}
