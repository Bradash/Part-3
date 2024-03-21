using UnityEngine;
using UnityEngine.UI;

public class SliderClock : MonoBehaviour
{
    public Slider slider;
    float t = 0f;
    private void Update()
    {

        if (slider.value < slider.maxValue)
        {
            if (t > 1) {
                t = 0;
                slider.value += 1;
                Debug.Log(t.ToString());
            }
            t += Time.deltaTime;
        }

    }

}
