using System.Collections;
using System.Collections.Generic;
using GJam2020.Avatar;
using UnityEngine;

namespace GJam2020.Core
{
    public class InputSystem : MonoBehaviour
    {
        //The box we control with keys
        public PlayerMovement playerMovement;
        //The different keys we need
        private Command _buttonW, _buttonS, _buttonA, _buttonD;

        private bool _isHandlingCommand;
        ////To reset the coroutine
        //private Coroutine _replayCoroutine;
        ////If we should start the replay
        //public static bool shouldStartReplay;

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

        private void Update()
        {
            if (CommandsManager.isRewinding) return;
            var lastCommand = CommandsManager.GetLastCommand;
            if (lastCommand == null)
            {
                if (!_isHandlingCommand)
                    HandleInput();
            }
            else
            {
                if (lastCommand.IsExecuting || lastCommand.ReverseCommand.IsExecuting ||
                                            _isHandlingCommand) return;
                HandleInput();
            }
        }


        //Check if we press a key, if so do what the key is binded to 
        public void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _isHandlingCommand = true;
                if (CommandsManager.IsLastCommandReverse(_buttonW))
                    CommandsManager.GetLastCommand.Undo(playerMovement, OnCommandDone);
                else
                    _buttonW.Execute(playerMovement, true, OnCommandDone);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                _isHandlingCommand = true;
                if (CommandsManager.IsLastCommandReverse(_buttonS))
                    CommandsManager.GetLastCommand.Undo(playerMovement, OnCommandDone);
                else
                    _buttonS.Execute(playerMovement, true, OnCommandDone);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _isHandlingCommand = true;
                if (CommandsManager.IsLastCommandReverse(_buttonA))
                    CommandsManager.GetLastCommand.Undo(playerMovement, OnCommandDone);
                else
                    _buttonA.Execute(playerMovement, true, OnCommandDone);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                _isHandlingCommand = true;
                if (CommandsManager.IsLastCommandReverse(_buttonD))
                    CommandsManager.GetLastCommand.Undo(playerMovement, OnCommandDone);
                else
                    _buttonD.Execute(playerMovement, true, OnCommandDone);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                CommandsManager.Instance.StartRewindCommands(playerMovement, (() => Debug.Log("Rewind finished")));
            }
        }

        public void OnCommandDone()
        {
            _isHandlingCommand = false;
            Debug.Log("Command done");
        }
    }
}
