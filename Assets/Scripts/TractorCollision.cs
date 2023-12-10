using UnityEngine;

public class TractorCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wheat"))
        {
            ChangeWheatMesh(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DirtPile"))
        {
            ActivateDirtPile(other.gameObject);
        }
    }
    private void ChangeWheatMesh(GameObject wheat)
    {
        CutWheatMesh cutWheatMesh = wheat.GetComponent<CutWheatMesh>();
        if (cutWheatMesh != null)
        {
            cutWheatMesh.RemoveMesh();
        }
    }

    private void ActivateDirtPile(GameObject dirtPile)
    {
        MeshRenderer dirtMeshRenderer = dirtPile.GetComponent<MeshRenderer>();
        if (dirtMeshRenderer != null)
        {
            dirtMeshRenderer.enabled = true;
        }
    }
}

