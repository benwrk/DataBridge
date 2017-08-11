using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
///     <para>
///         A custom input module for the EventSystem that enables the user to interact with the in-game Unity UI objects
///         with the crosshair.
///     </para>
///     Refer to https://forum.unity3d.com/threads/fake-mouse-position-in-4-6-ui-answered.283748/ for more information.
/// </summary>
public class FpsUiAwareInputModule : StandaloneInputModule
{
    private readonly MouseState _mouseState = new MouseState();
    private Vector2 _cursorPosition;

    public override void UpdateModule()
    {
        _cursorPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
        // Debug.Log("MDS: " +_cursorPosition + " | MPS: " + Input.mousePosition);
    }

    private new bool GetPointerData(int id, out PointerEventData data, bool create)
    {
        if (m_PointerData.TryGetValue(id, out data) || !create)
            return false;

        data = new PointerEventData(eventSystem)
        {
            pointerId = id
        };
        m_PointerData.Add(id, data);
        return true;
    }

    private new void CopyFromTo(PointerEventData from, PointerEventData to)
    {
        to.position = from.position;
        to.delta = from.delta;
        to.scrollDelta = from.scrollDelta;
        to.pointerCurrentRaycast = from.pointerPressRaycast;
    }

    protected override MouseState GetMousePointerEventData(int id)
    {
        PointerEventData leftData;
        var created = GetPointerData(kMouseLeftId, out leftData, true);

        leftData.Reset();

        if (created)
            leftData.position = _cursorPosition;

        var position = _cursorPosition;
        leftData.delta = position - leftData.position;
        leftData.position = position;
        leftData.scrollDelta = Input.mouseScrollDelta;
        leftData.button = PointerEventData.InputButton.Left;
        eventSystem.RaycastAll(leftData, m_RaycastResultCache);
        var raycast = FindFirstRaycast(m_RaycastResultCache);
        leftData.pointerCurrentRaycast = raycast;
        m_RaycastResultCache.Clear();

        PointerEventData rightData;
        GetPointerData(kMouseRightId, out rightData, true);
        CopyFromTo(leftData, rightData);
        rightData.button = PointerEventData.InputButton.Right;

        PointerEventData middleData;
        GetPointerData(kMouseMiddleId, out middleData, true);
        CopyFromTo(leftData, middleData);
        middleData.button = PointerEventData.InputButton.Middle;

        // For controllers
        // var selectState = PointerEventData.FramePressState.NotChanged;
        // if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        // {
        //     selectState = PointerEventData.FramePressState.Pressed;
        // }
        // else if (Input.GetKeyUp(KeyCode.Joystick1Button0))
        // {
        //     selectState = PointerEventData.FramePressState.Released;
        // }
        // _mouseState.SetButtonState(PointerEventData.InputButton.Left, selectState, leftData);

        _mouseState.SetButtonState(PointerEventData.InputButton.Left, StateForMouseButton(0), leftData);
        _mouseState.SetButtonState(PointerEventData.InputButton.Right, StateForMouseButton(1), rightData);
        _mouseState.SetButtonState(PointerEventData.InputButton.Middle, StateForMouseButton(2), middleData);

        return _mouseState;
    }
}