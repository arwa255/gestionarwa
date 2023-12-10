using UnityEngine;

public class HarvesterCollision : MonoBehaviour
{
    public int wheatGathered;
    public GameObject hayBalePrefab;
    public Transform shootPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wheat"))
        {
            wheatGathered++;
            ChangeWheatMesh(other.gameObject);

            if (wheatGathered % 10 == 0)
            {
                SpawnHayBale();
            }
        }
    }

    private void ChangeWheatMesh(GameObject wheat)
    {
        CutWheatMesh cutWheatMesh = wheat.GetComponent<CutWheatMesh>();
        if (cutWheatMesh != null)
        {
            cutWheatMesh.CutMesh();
        }
    }

    private void SpawnHayBale()
    {
        if (hayBalePrefab != null)
        {
            GameObject hayBale = Instantiate(hayBalePrefab, shootPoint.position, Quaternion.identity);
        }
    }
}
