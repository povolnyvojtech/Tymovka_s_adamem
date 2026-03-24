using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetFocusOnNextInput : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField surnameInput;

    private void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Tab))
        {
            nameInput.DeactivateInputField();
            surnameInput.ActivateInputField();
        }
    }
}
