using UnityEngine;
using UnityEngine.EventSystems;

public class CustomInputModule : StandaloneInputModule
{
    private Vector2 _cursorPosition;

    public override void UpdateModule()
    {
        _cursorPosition = Input.mousePosition;
    }

    protected new bool GetPointerData(int id, out PointerEventData data, bool create)
    {
        if (!m_PointerData.TryGetValue(id, out data) && create)
        {
            data = new PointerEventData(eventSystem)
            {
                pointerId = id
            };
            m_PointerData.Add(id, data);
            return true;
        }
        return false;
    }

    private new void CopyFromTo(PointerEventData @from, PointerEventData @to)
    {
        @to.position = @from.position;
        @to.delta = @from.delta;
        @to.scrollDelta = @from.scrollDelta;
        @to.pointerCurrentRaycast = @from.pointerPressRaycast;
    }

    private readonly MouseState _mouseState = new MouseState();

    protected override MouseState GetMousePointerEventData()
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

        //For controllers
        //var selectState = PointerEventData.FramePressState.NotChanged;
        //if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        //{
        //    selectState = PointerEventData.FramePressState.Pressed;
        //}
        //else if (Input.GetKeyUp(KeyCode.Joystick1Button0))
        //{
        //    selectState = PointerEventData.FramePressState.Released;
        //}
        //_mouseState.SetButtonState(PointerEventData.InputButton.Left, selectState, leftData);

        _mouseState.SetButtonState(PointerEventData.InputButton.Left, StateForMouseButton(0), leftData);
        _mouseState.SetButtonState(PointerEventData.InputButton.Right, StateForMouseButton(1), rightData);
        _mouseState.SetButtonState(PointerEventData.InputButton.Middle, StateForMouseButton(2), middleData);

        return _mouseState;
    }
}