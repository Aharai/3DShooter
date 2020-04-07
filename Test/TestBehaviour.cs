using UnityEngine;


namespace Geekbrains
{
	public class TestBehaviour : MonoBehaviour
	{
		public Vector3 center;
		public Vector3 size;

		public int count = 10;
		public int offset = 1;
		public GameObject obj;

		public float Test;
		private Transform _root;


		private void Awake()
		{
			Debug.Log(3445436);
		}

		private void Start()
		{
			CreateObj();
		}

		public void CreateObj()
		{
			_root = new GameObject("Root").transform;
			for (var i = 1; i <= count; i++)
			{
				Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),
					Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
				Instantiate(obj, pos, Quaternion.identity, _root);
			}
		}

		public void AddComponent()
		{
			gameObject.AddComponent<Rigidbody>();
			gameObject.AddComponent<MeshRenderer>();
			gameObject.AddComponent<BoxCollider>();
		}

		public void RemoveComponent()
		{
			DestroyImmediate(GetComponent<Rigidbody>());
			DestroyImmediate(GetComponent<MeshRenderer>());
			DestroyImmediate(GetComponent<BoxCollider>());
		}

		//private void OnGUI()
		//{
		//	GUI.Button(new Rect(Screen.width/2, Screen.height/2, 100, 20), "Click Me");
		//}
	}
}