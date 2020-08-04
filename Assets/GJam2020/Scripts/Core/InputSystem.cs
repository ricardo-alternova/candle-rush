using System.Collections.Generic;
using GJam2020.Avatar;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace GJam2020.Core
{
    public class InputSystem : MonoBehaviour
    {
        //The box we control with keys
        public PlayerMovement playerMovement;
        //The different keys we need
        private Command _buttonW, _buttonS, _buttonA, _buttonD;

        public UnityEvent OnInputReleased;

        public delegate void MoveCallback(Vector2 direction);
        public event MoveCallback OnMove;
        
        private bool _isHandlingCommand;
        private Vector2 moveValue;
        private Vector2 meanDrag = Vector2.zero;
        private bool startDragg;
        private List<Vector2> _directionsEnabled;
        private bool _pressing;

        ////To reset the coroutine
        //private Coroutine _replayCoroutine;
        ////If we should start the replay
        //public static bool shouldStartReplay;
        [SerializeField]
        private PlayerInputActions inputActions;

        private void Awake()
        {
            _directionsEnabled = new List<Vector2>();
            EnableInputs(true, true, true, true);

            inputActions = new PlayerInputActions();
            
            inputActions.Player.Move.performed += moveAction => {
                CheckMoveInput(moveAction.ReadValue<Vector2>());
                };
        }

        
        private void FixedUpdate()
        {
            //#if UNITY_WEBGL
            if (Input.touchCount < 1)
            {
                playerMovement.StopWalking();
                return;
            } 

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                meanDrag += Input.GetTouch(0).deltaPosition;
                if (meanDrag.magnitude > 70f)
                {
                    startDragg = true;
                    moveValue = meanDrag.normalized * 100;

                    moveValue.x = Mathf.Abs(moveValue.x) < 75f ? 0 : moveValue.x;
                    moveValue.y = Mathf.Abs(moveValue.y) < 75f ? 0 : moveValue.y;
                }
            }

            if (startDragg)
            {


                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    moveValue = Vector2.zero;
                    startDragg = false;
                    meanDrag = Vector2.zero;
                }
            }
            

#if UNITY_IOS
            CheckMoveInput(moveValue);
#else
            CheckMoveInput(moveValue * -1);
#endif
            //#else

            ////moveValue = inputActions.Player.Move. ReadValue<Vector2>();
            //if (Touch.activeTouches.Count > 0) {
            //    var touch = Touch.activeTouches[0];
            //    moveValue = touch.delta;
            //    moveValue.x = Mathf.Abs(moveValue.x) < 75f ? 0 : moveValue.x;
            //    moveValue.y = Mathf.Abs(moveValue.y) < 75f ? 0 : moveValue.y;
            //    //_debugText.text = moveValue.ToString();
            //}
            //#endif
        }

        private void Start()
        {
            //Bind keys with commands
            _buttonW = new MoveForward();
            _buttonS = new MoveBackward();
            _buttonA = new MoveLeft();
            _buttonD = new MoveRight();
            _buttonW.ReverseCommand = _buttonS;
            _buttonS.ReverseCommand = _buttonW;
            _buttonA.ReverseCommand = _buttonD;
            _buttonD.ReverseCommand = _buttonA;

            _buttonW.Restore();
            _buttonS.Restore();
            _buttonA.Restore();
            _buttonD.Restore();

        }

        public void EnableInputs(bool left, bool right, bool up, bool down)
        {
            _directionsEnabled.Clear();
            if (left) _directionsEnabled.Add(Vector2.left);
            if (right) _directionsEnabled.Add(Vector2.right);
            if (up) _directionsEnabled.Add(Vector2.up);
            if (down) _directionsEnabled.Add(Vector2.down);
        }

        public void OnCommandDone()
        {
            _isHandlingCommand = false;
        }
        
        private void CheckMoveInput(Vector2 direction)
        {
            
            if (GameManager.Get.IsPlaying == false) return;
#if UNITY_ANDROID
            direction = moveValue.magnitude != 0 ? moveValue : direction;
#endif
            if(_pressing && direction.magnitude == 0)
            {
                OnInputReleased.Invoke();
            }

            if (direction.x != 0) {
                if (direction.x > 0)
                {
                    LaunchInput(_buttonD, Vector2.right);
                }
                if (direction.x < 0)
                {
                    LaunchInput(_buttonA, Vector2.left);
                }
                _pressing = true;
            }
            else if (direction.y != 0)
            {
                if (direction.y > 0)
                {
                    LaunchInput(_buttonW, Vector2.up);
                }
                if (direction.y < 0)
                {
                    LaunchInput(_buttonS, Vector2.down);
                }
                _pressing = true;
            }
            else
            {
                _pressing = false;
            }
        }

        private void LaunchInput(Command command, Vector2 direction)
        {
            if (!_directionsEnabled.Contains(direction)) return;
            OnMove?.Invoke(direction);
            DecideAction(command);
        }

        private void DecideAction(Command command)
        {
            if (CommandsManager.isRewinding) return;
            var lastCommand = CommandsManager.GetLastCommand;
            if (lastCommand == null)
            {
                if (!_isHandlingCommand)
                    CommandPressed(command);
            }
            else
            {
                if (lastCommand.IsExecuting || 
                    lastCommand.ReverseCommand.IsExecuting ||                        
                    _isHandlingCommand) return;
                CommandPressed(command);
                //HandleInput();
            }
        }
        
        //Check if we press a key, if so do what the key is binded to 
        //public void HandleInput()
        //{
        //    if (Input.GetKeyDown(KeyCode.W))
        //    {
        //        _isHandlingCommand = true;
        //        if (CommandsManager.IsLastCommandReverse(_buttonW))
        //            CommandsManager.GetLastCommand.Undo(playerMovement, OnCommandDone);
        //        else
        //            _buttonW.Execute(playerMovement, true, OnCommandDone);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.S))
        //    {
        //        _isHandlingCommand = true;
        //        if (CommandsManager.IsLastCommandReverse(_buttonS))
        //            CommandsManager.GetLastCommand.Undo(playerMovement, OnCommandDone);
        //        else
        //            _buttonS.Execute(playerMovement, true, OnCommandDone);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.A))
        //    {
        //        _isHandlingCommand = true;
        //        if (CommandsManager.IsLastCommandReverse(_buttonA))
        //            CommandsManager.GetLastCommand.Undo(playerMovement, OnCommandDone);
        //        else
        //            _buttonA.Execute(playerMovement, true, OnCommandDone);
        //    }
        //    else if (Input.GetKeyDown(KeyCode.D))
        //    {
        //        _isHandlingCommand = true;
        //        if (CommandsManager.IsLastCommandReverse(_buttonD))
        //            CommandsManager.GetLastCommand.Undo(playerMovement, OnCommandDone);
        //        else
        //            _buttonD.Execute(playerMovement, true, OnCommandDone);
        //    }

        //    //if (Input.GetKeyDown(KeyCode.R))
        //    //{
        //    //    CommandsManager.Instance.StartRewindCommands(playerMovement, (() => Debug.Log("Rewind finished")));
        //    //}
        //}

        private void CommandPressed(Command command)
        {
            _isHandlingCommand = true;
            if (CommandsManager.IsLastCommandReverse(command))
            {
                AvatarGeneralManager.Get.StepBack();
                CommandsManager.GetLastCommand.Undo(playerMovement, OnCommandDone);
            }
            else
                command.Execute(playerMovement, true, OnCommandDone);
        }
        
        private void OnEnable()
        {
            inputActions.Enable();
            EnhancedTouchSupport.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
            EnhancedTouchSupport.Disable();
        }
    }
}
