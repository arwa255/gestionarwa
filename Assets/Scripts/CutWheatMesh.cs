using UnityEngine;

public class CutWheatMesh : MonoBehaviour
{
    public Mesh cutMesh;  

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void CutMesh()
    {
        if (cutMesh != null && meshFilter != null)
        {
            meshFilter.mesh = cutMesh;
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxCollider.enabled = false;
            }
        }
    }
    public void RemoveMesh()
    {
        meshRenderer.enabled = false;
    }
}

