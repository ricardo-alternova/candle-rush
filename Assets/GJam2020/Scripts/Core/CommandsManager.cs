using System;
using System.Collections;
using System.Collections.Generic;
using GJam2020.Avatar;
using UnityEngine;

namespace GJam2020.Core
{
    public class CommandsManager : MonoBehaviour
    {
        public static CommandsManager Instance { get; private set; }

        public static bool isRewinding;
        //Stores all commands for replay and undo
        private static readonly List<Command> MovementsCommandsEntered = new List<Command>();

        public static Command GetLastCommand => MovementsCommandsEntered[MovementsCommandsEntered.Count - 1];

        private void Awake()
        {
            Instance = this;
        }

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
            StartCoroutine(RewindCommands(playerMovement));
        }

        private static IEnumerator RewindCommands(PlayerMovement playerMovement)
        {
            while (MovementsCommandsEntered.Count > 0)
            {
                var commandToRewind = GetLastCommand;
                commandToRewind.Undo(playerMovement);
                while (commandToRewind.isExecuting)
                    yield return null;
                yield return new WaitForSeconds(0.1f);// TODO Remove
            }

            isRewinding = false;
        }
    }
}
