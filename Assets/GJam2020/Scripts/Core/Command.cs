using System;
using System.Diagnostics;
using GJam2020.Avatar;

namespace GJam2020.Core
{
    public abstract class Command
    {
        public Command ReverseCommand { get; set; }

        //Move and save command
        public abstract void Execute(PlayerMovement playerMovement, bool needToBeSaved, Action onCommandComplete, float timeForDisplacement = 1);

        //Undo an old command
        public abstract void Undo(PlayerMovement playerMovement, Action onCommandComplete, float timeForDisplacement = 1);

        protected bool isExecuting;

        public bool IsExecuting => isExecuting;

        protected void OnExecutionComplete(Action onCommandComplete)
        {
            UnityEngine.Debug.Log("Command Executed");
            isExecuting = false;
            onCommandComplete();
        }

    }

    public class MoveForward : Command
    {
        //Called when we press a key
        public override void Execute(PlayerMovement playerMovement, bool needToBeSaved, Action onCommandComplete, float timeForDisplacement = 1)
        {
            isExecuting = true;
            //Move the box
            var isValidMovement = playerMovement.Move(MovementDirection.Forward, () => OnExecutionComplete(onCommandComplete), timeForDisplacement);

            //Save the command
            if (!needToBeSaved || !isValidMovement) return;
            CommandsManager.AddCommand(this);

        }

        //Undo an old command
        public override void Undo(PlayerMovement playerMovement, Action onCommandComplete, float timeForDisplacement = 1)
        {
            AvatarGeneralManager.Get.IsReverseCommand();
            ReverseCommand.Execute(playerMovement, false, () => OnExecutionComplete(onCommandComplete), timeForDisplacement);
            BodyDestruction.Instance.ReconstructBodyPart();
            CommandsManager.RemoveLastCommand();
        }
    }

    public class MoveBackward : Command
    {
        //Called when we press a key
        public override void Execute(PlayerMovement playerMovement, bool needToBeSaved, Action onCommandComplete, float timeForDisplacement = 1)
        {
            isExecuting = true;

            //Move the box
            var isValidMovement = playerMovement.Move(MovementDirection.Backward,() => OnExecutionComplete(onCommandComplete), timeForDisplacement);
            
            //Save the command
            if (!needToBeSaved || !isValidMovement) return;
            CommandsManager.AddCommand(this);
        }

        //Undo an old command
        public override void Undo(PlayerMovement playerMovement, Action onCommandComplete, float timeForDisplacement = 1)
        {
            AvatarGeneralManager.Get.IsReverseCommand();
            ReverseCommand.Execute(playerMovement, false, () =>OnExecutionComplete(onCommandComplete), timeForDisplacement);
            BodyDestruction.Instance.ReconstructBodyPart();
            CommandsManager.RemoveLastCommand();
        }
    }

    public class MoveLeft : Command
    {
        //Called when we press a key
        public override void Execute(PlayerMovement playerMovement, bool needToBeSaved, Action onCommandComplete, float timeForDisplacement = 1)
        {
            isExecuting = true;

            //Move the box
            var isValidMovement = playerMovement.Move(MovementDirection.Left,() => OnExecutionComplete(onCommandComplete), timeForDisplacement);

            //Save the command
            if (!needToBeSaved || !isValidMovement) return;
            CommandsManager.AddCommand(this);
        }

        //Undo an old command
        public override void Undo(PlayerMovement playerMovement, Action onCommandComplete, float timeForDisplacement = 1)
        {
            AvatarGeneralManager.Get.IsReverseCommand();
            ReverseCommand.Execute(playerMovement, false,() => OnExecutionComplete(onCommandComplete), timeForDisplacement);
            BodyDestruction.Instance.ReconstructBodyPart();
            CommandsManager.RemoveLastCommand();
        }
    }

    public class MoveRight : Command
    {
        //Called when we press a key
        public override void Execute(PlayerMovement playerMovement, bool needToBeSaved, Action onCommandComplete, float timeForDisplacement = 1)
        {
            isExecuting = true;

            //Move the box
            var isValidMovement = playerMovement.Move(MovementDirection.Right,() => OnExecutionComplete(onCommandComplete), timeForDisplacement);

            //Save the command
            if (!needToBeSaved || !isValidMovement) return;
            CommandsManager.AddCommand(this);
        }

        //Undo an old command
        public override void Undo(PlayerMovement playerMovement, Action onCommandComplete, float timeForDisplacement = 1)
        {
            AvatarGeneralManager.Get.IsReverseCommand();
            ReverseCommand.Execute(playerMovement, false,()=> OnExecutionComplete(onCommandComplete), timeForDisplacement);
            BodyDestruction.Instance.ReconstructBodyPart();
            CommandsManager.RemoveLastCommand();
        }
    }
}
