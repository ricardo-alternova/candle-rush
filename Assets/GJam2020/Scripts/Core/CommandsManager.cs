using System;
using System.Collections;
using System.Collections.Generic;
using GJam2020.Avatar;
using JetBrains.Annotations;
using UnityEngine;

namespace GJam2020.Core
{
    public class CommandsManager : MonoBehaviour
    {
        public static CommandsManager Instance { get; private set; }

        public static bool isRewinding;
        //Stores all commands for replay and undo
        private static readonly List<Command> MovementsCommandsEntered = new List<Command>();

        private void Awake()
        {
            Instance = this;
            MovementsCommandsEntered.RemoveRange(0, MovementsCommandsEntered.Count);
        }

        public static Command GetLastCommand => MovementsCommandsEntered.Count > 0
            ? MovementsCommandsEntered[MovementsCommandsEntered.Count - 1]
            : null;

        public static int GetCommandsEntered => MovementsCommandsEntered.Count;

        public static void AddCommand(Command commandToAdd)
        {
            MovementsCommandsEntered.Add(commandToAdd);
        }

        public static void RemoveLastCommand()
        {
            MovementsCommandsEntered.RemoveAt(MovementsCommandsEntered.Count-1);
        }

        public static bool IsLastCommandReverse(Command commandToCompare)
        {
            if (MovementsCommandsEntered.Count > 0)
                return GetLastCommand.ReverseCommand == commandToCompare;
            return false;
        }

        public void StartRewindCommands(PlayerMovement playerMovement, Action onComplete)
        {
            isRewinding = true;
            StartCoroutine(RewindCommands(playerMovement, onComplete));
        }

        private static IEnumerator RewindCommands(PlayerMovement playerMovement, Action onComplete)
        {
            var lastCommand = GetLastCommand;
            while (MovementsCommandsEntered.Count > 0)
            {
                while (lastCommand.IsExecuting || lastCommand.ReverseCommand.IsExecuting)
                    yield return null;

                lastCommand = GetLastCommand;
                lastCommand.Undo(playerMovement,() =>Debug.Log("Done rewind step"),0.1f);
                while (lastCommand.IsExecuting || lastCommand.ReverseCommand.IsExecuting)
                    yield return null;
            }
            playerMovement.ResetRotation();
            isRewinding = false;
            onComplete.Invoke();
        }
    }
}
