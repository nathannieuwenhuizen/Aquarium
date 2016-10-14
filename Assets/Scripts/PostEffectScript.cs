using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PostEffectScript : MonoBehaviour {

    [SerializeField]
    Material mat;

    void OnRenderImage (RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, mat);
    }
}
