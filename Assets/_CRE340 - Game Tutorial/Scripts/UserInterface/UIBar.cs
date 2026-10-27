using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    public Slider slider;
    public float speed = 8f;

    private float target = 1f;

    private void Awake()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
    }

    public void SetValue(int current, int max)
    {
        if (max <= 0)
        {
            target = 0f;
            return;
        }

        // The (float) casts matter - int divided by int is integer division,
        // so 50 / 100 would give us 0 rather than 0.5 //maths and programming!

        target = (float)current / (float)max;
    }

    private void Update()
    {
        if (slider == null)
        {
            return;
        }

        slider.value = Mathf.Lerp(slider.value, target, Time.deltaTime * speed);
    }

}
