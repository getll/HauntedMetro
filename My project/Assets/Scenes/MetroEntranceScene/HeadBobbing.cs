using UnityEngine;

public class HeadBobbing : MonoBehaviour
{
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.2f;
    public float breathingSpeed = 0.05f;
    public float breathingAmount = 0.02f;

    public string walkingAxis = "Vertical";
    public string sprintingAxis = "Run";
    public float sprintingMultiplier = 2f;

    private float timer = 0f;
    private Vector3 originalPosition;
    private float movement;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        float waveslice = 0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis(walkingAxis);
        float sprint = Input.GetAxis(sprintingAxis);
        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0 && Mathf.Abs(sprint) == 0)
        {
            timer = 0f;
            movement = 0f;
            BreathingEffect();
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }

            movement = Mathf.Clamp(Mathf.Abs(horizontal) + Mathf.Abs(vertical) + Mathf.Abs(sprint), 0f, 1f);
            BobbingEffect();
        }
    }

    float waveslice = 0f;

    private void BreathingEffect()
    {
        waveslice = Mathf.Sin(timer);
        timer = timer + breathingSpeed;
        if (timer > Mathf.PI * 2)
        {
            timer = timer - (Mathf.PI * 2);
        }
        float translateChange = waveslice * breathingAmount;
        transform.localPosition = originalPosition + new Vector3(0f, translateChange, 0f);
    }

    private void BobbingEffect()
    {
        waveslice = 0f;
        float translateChange = waveslice * bobbingAmount * movement * sprintingMultiplier;
        transform.localPosition = originalPosition + new Vector3(0f, translateChange, 0f);
    }
}
