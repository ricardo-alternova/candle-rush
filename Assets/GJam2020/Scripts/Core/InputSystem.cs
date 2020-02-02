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
        }

        private void Update()
        {
            if (CommandsManager.isRewinding) return;
            var lastCommand = CommandsManager.GetLastCommand;
            
            if (lastCommand == null)
            {
                HandleInput();
            }
            else
            {
                if (lastCommand.IsExecuting || lastCommand.ReverseCommand.IsExecuting) return;
                HandleInput();
            }
        }


        //Check if we press a key, if so do what the key is binded to 
        public void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if(CommandsManager.IsLastCommandReverse(_buttonW))
                    CommandsManager.GetLastCommand.Undo(playerMovement);
                else
                    _buttonW.Execute(playerMovement, true);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (CommandsManager.IsLastCommandReverse(_buttonS))
                    CommandsManager.GetLastCommand.Undo(playerMovement);
                else
                    _buttonS.Execute(playerMovement, true);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (CommandsManager.IsLastCommandReverse(_buttonA))
                    CommandsManager.GetLastCommand.Undo(playerMovement);
                else
                    _buttonA.Execute(playerMovement, true);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (CommandsManager.IsLastCommandReverse(_buttonD))
                    CommandsManager.GetLastCommand.Undo(playerMovement);
                else
                    _buttonD.Execute(playerMovement, true);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                CommandsManager.Instance.StartRewindCommands(playerMovement, (() => Debug.Log("Rewind finished")));
            }
        }
    }
}
