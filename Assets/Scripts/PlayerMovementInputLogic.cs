using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovementInputLogic : InputLogic {
    #region Fields
        public delegate void OnMoveInput(Vector2 inputVector);
        public event OnMoveInput onMoveInputEvent;
    #endregion

    #region Event Methods
        protected override void FireInputEvents() {
            FireMovementInputEvents();
        }

        private void FireMovementInputEvents() {
            float inputX = input.GetAxisRaw(RewiredConsts.Action.Move_Horizontal);
            float inputY = input.GetAxisRaw(RewiredConsts.Action.Move_Vertical);
            Vector2 inputVector = new Vector2(inputX, inputY);

            onMoveInputEvent?.Invoke(inputVector);
        }
    #endregion
}
