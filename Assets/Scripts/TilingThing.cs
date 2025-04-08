using UnityEngine;

public class AutoTileMaterial : MonoBehaviour
{
    public Renderer objectRenderer; // Assign the object's renderer
    public Vector2 tilingMultiplier = new Vector2(1, 1); // Controls scaling

    void Start()
    {
        if (objectRenderer == null)
            objectRenderer = GetComponent<Renderer>(); // Get the renderer if not set

        if (objectRenderer != null && objectRenderer.material != null)
        {
            Vector3 scale = transform.localScale;
            objectRenderer.material.mainTextureScale = new Vector2(scale.x * tilingMultiplier.x, scale.z * tilingMultiplier.y);
        }
    }
}
