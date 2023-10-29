using System;
using UnityEngine;

public class InputManager
{
    public enum InputType
    {
        TOUCH,
        ACCELEROMETER,
    }

    public readonly static string INPUT_KEY = "INPUT_KEY";
    public static void SetInputType(InputType inputType)
    {
        PlayerPrefs.SetString(INPUT_KEY, inputType.ToString());
    }

    public static InputType GetInputType()
    {
        return Enum.Parse<InputType>(PlayerPrefs.GetString(INPUT_KEY, InputType.TOUCH.ToString()));
    }
}
