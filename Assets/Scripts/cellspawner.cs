using System.Collections;
using UnityEngine;

public class cellspawner : MonoBehaviour
{
    public GameObject redcellPrefab;
    public GameObject whitecellPrefab;
    public float redSpawnInterval = 0.5f;
    public float whiteSpawnInterval = 1.2f;

    void Start()
    {
        StartCoroutine(SpawnRedCells());
        StartCoroutine(SpawnWhiteCells());
    }

    IEnumerator SpawnRedCells()
    {
        while (true)
        {
            float yPos = Random.Range(transform.position.y - 1, transform.position.y + 1);
            GameObject newCell = Instantiate(redcellPrefab, new Vector3(transform.position.x, yPos, transform.position.z), transform.rotation);
            yield return new WaitForSeconds(redSpawnInterval);
        }
    }

    IEnumerator SpawnWhiteCells()
    {
        while (true)
        {
            float yPos = Random.Range(transform.position.y - 1, transform.position.y + 1);
            GameObject newCell = Instantiate(whitecellPrefab, new Vector3(transform.position.x, yPos, transform.position.z), transform.rotation);
            yield return new WaitForSeconds(whiteSpawnInterval);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buttom") || other.CompareTag("Top"))
        {
            StartCoroutine(MoveCell(other.gameObject));
        }
    }

    IEnumerator MoveCell(GameObject cell)
    {
        float targetYPos = (cell.CompareTag("Buttom")) ? 3.0f : -3.0f;
        float direction = (cell.CompareTag("Buttom")) ? -1.0f : 1.0f;

        while (Mathf.Abs(cell.transform.position.y - targetYPos) > 0.01f)
        {
            float step = 3.0f * direction * Time.deltaTime;
            cell.transform.position += Vector3.up * step;
            yield return null;
        }

        yield return new WaitForSeconds(3.0f); 

        Destroy(cell);
    }
}
