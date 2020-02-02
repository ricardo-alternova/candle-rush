using System.Collections.Generic;
using GJam2020.Avatar;
using UnityEngine;

namespace GJam2020.Core
{
    public abstract class Command
    {
        public Command ReverseCommand { get; set; }

        //Move and save command
        public abstract void Execute(PlayerMovement playerMovement, bool needToBeSaved, float timeForDisplacement = 1);

        //Undo an old command
        public abstract void Undo(PlayerMovement playerMovement, float timeForDisplacement = 1);

        protected bool isExecuting;

        public bool IsExecuting => isExecuting;

        protected void OnExecutionComplete()
        {
            isExecuting = false;
        }

    }

    public class MoveForward : Command
    {
        //Called when we press a key
        public override void Execute(PlayerMovement playerMovement, bool needToBeSaved, float timeForDisplacement = 1)
        {
            isExecuting = true;
            //Move the box
            var isValidMovement = playerMovement.Move(MovementDirection.Forward, OnExecutionComplete, timeForDisplacement);

            //Save the command
            if (!needToBeSaved || !isValidMovement) return;
            CommandsManager.AddCommand(this);

        }

        //Undo an old command
        public override void Undo(PlayerMovement playerMovement, float timeForDisplacement = 1)
        {
            Debug.Log("undoing");
            ReverseCommand.Execute(playerMovement, false, timeForDisplacement);
            CommandsManager.RemoveLastCommand();
        }
    }

    public class MoveBackward : Command
    {
        //Called when we press a key
        public override void Execute(PlayerMovement playerMovement, bool needToBeSaved, float timeForDisplacement = 1)
        {
            Debug.Log("Executing");
            isExecuting = true;

            //Move the box
            var isValidMovement = playerMovement.Move(MovementDirection.Backward, OnExecutionComplete, timeForDisplacement);
            
            //Save the command
            if (!needToBeSaved || !isValidMovement) return;
            CommandsManager.AddCommand(this);
        }

        //Undo an old command
        public override void Undo(PlayerMovement playerMovement, float timeForDisplacement = 1)
        {
            ReverseCommand.Execute(playerMovement, false, timeForDisplacement);
            CommandsManager.RemoveLastCommand();
        }
    }

    public class MoveLeft : Command
    {
        //Called when we press a key
        public override void Execute(PlayerMovement playerMovement, bool needToBeSaved, float timeForDisplacement = 1)
        {
            isExecuting = true;

            //Move the box
            var isValidMovement = playerMovement.Move(MovementDirection.Left, OnExecutionComplete, timeForDisplacement);

            //Save the command
            if (!needToBeSaved || !isValidMovement) return;
            CommandsManager.AddCommand(this);
        }

        //Undo an old command
        public override void Undo(PlayerMovement playerMovement, float timeForDisplacement = 1)
        {
            ReverseCommand.Execute(playerMovement, false, timeForDisplacement);
            CommandsManager.RemoveLastCommand();
        }
    }

    public class MoveRight : Command
    {
        //Called when we press a key
        public override void Execute(PlayerMovement playerMovement, bool needToBeSaved, float timeForDisplacement = 1)
        {
            isExecuting = true;

            //Move the box
            var isValidMovement = playerMovement.Move(MovementDirection.Right, OnExecutionComplete, timeForDisplacement);

            //Save the command
            if (!needToBeSaved || !isValidMovement) return;
            CommandsManager.AddCommand(this);
        }

        //Undo an old command
        public override void Undo(PlayerMovement playerMovement, float timeForDisplacement = 1)
        {
            ReverseCommand.Execute(playerMovement, false, timeForDisplacement);
            CommandsManager.RemoveLastCommand();
        }
    }
}
