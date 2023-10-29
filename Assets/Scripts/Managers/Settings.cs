using UnityEngine;

public class Settings : MonoBehaviour
{
    public void SetInputScreen()
    {
        InputManager.SetInputType(InputManager.InputType.TOUCH);
        gameObject.SetActive(false);
    }
    public void SetInputAccelerometer()
    {
        InputManager.SetInputType(InputManager.InputType.ACCELEROMETER);
        gameObject.SetActive(false);
    }
}
