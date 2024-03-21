using System.Collections;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject[] building;
    float speed = 0.5f;
    private void Start()
    {
        StartCoroutine(buildIn());
        for (int i = 0; i < 3; i++)
        {
            building[i].transform.localScale = Vector3.zero;
        }
    }
    IEnumerator buildIn()
    {
        for (float time = 0; time < speed; time += Time.deltaTime)
{
            float scaleFactor = time / speed;
                                           
            building[0].transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(0.88509f, 0.88509f, 0.88509f), scaleFactor);
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        for (float time = 0; time < speed; time += Time.deltaTime)
        {
            float scaleFactor = time / speed;

            building[1].transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(2.5645f, 2.5645f, 2.5645f), scaleFactor);
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        for (float time = 0; time < speed; time += Time.deltaTime)
        {
            float scaleFactor = time / speed;

            building[2].transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(0.5948957f, 1.619397f, 2.382561f), scaleFactor);
            yield return null;
        }
        yield return null;
    }

}
