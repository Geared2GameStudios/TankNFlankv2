using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class lightPillar : MonoBehaviour {

	public Color ObjectColor;
	
	private Color currentColor;
	private Material materialColored;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ObjectColor != currentColor)
		{
			//stop the leaks
			//if (materialColored != null)
				//UnityEditor.AssetDatabase.DeleteAsset(UnityEditor.AssetDatabase.GetAssetPath(materialColored));
			
			//create a new material
			materialColored = new Material(Shader.Find("Diffuse"));
			materialColored.color = currentColor = ObjectColor;
			this.renderer.material = materialColored;
		}
	}
}
