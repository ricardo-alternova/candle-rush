using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.InputSystem.InputAction;

public class FocusDefect : MonoBehaviour
{
    public GameObject goSelected;
    private UiInput inputActions;
    // Start is called before the first frame update
    void Start()
    {
        if (goSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(goSelected);
        }
        inputActions = new UiInput();
        inputActions.Ui.RightLS.started += Actions;
        inputActions.Ui.LeftLS.started += Actions;
        inputActions.Ui.UpLS.started += Actions;
        inputActions.Ui.DownLS.started += Actions;
        inputActions.Enable();
    }

    private void Actions(CallbackContext obj)
    {
        if (goSelected != null)
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(goSelected);
            }
        }
    }
}
