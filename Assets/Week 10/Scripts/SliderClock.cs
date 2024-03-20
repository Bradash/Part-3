using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderClock : MonoBehaviour
{
    public Slider slider;
    float t = 0f;

    IEnumerator Counting()
    {
        while (t < 60)
        {
            slider.value += 1;
            t += Time.deltaTime;
        }
        yield return null;

    }
}
