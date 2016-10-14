using UnityEngine;
using System.Collections;
/// <summary>
/// This class is responsible for the fog of the scene.
/// </summary>
public class Fog : MonoBehaviour {

    [SerializeField]
    private float fogDensity = 0.08f;

    void Awake () {
        RenderSettings.fogColor = Camera.main.backgroundColor;
        RenderSettings.fogDensity = fogDensity;
        RenderSettings.fog = true;
	}
	
}
