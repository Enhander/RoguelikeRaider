using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovementInputLogic : InputLogic {
    #region Fields
        public delegate void OnMoveInput(float direction);
        public event OnMoveInput onMoveInputEvent;

        public delegate void OnStrafeInput(float direction);
        public event OnStrafeInput onStrafeInputEvent;

        public delegate void OnFacingInput(Vector2 mousePoint);
        public event OnFacingInput onFacingInputEvent;
    #endregion

    #region Event Methods
        protected override void FireInputEvents() {
            FireMovementInputEvents();
        }

        private void FireMovementInputEvents() {
            MoveInputEvent();
            StrafeInputEvent();
            FacingInputEvent();
        }

        private void MoveInputEvent() {
            float direction = input.GetAxisRaw(RewiredConsts.Action.Move_Vertical);

            onMoveInputEvent?.Invoke(direction);
        }

        private void StrafeInputEvent() {
            float direction = input.GetAxisRaw(RewiredConsts.Action.Move_Horizontal);

            onStrafeInputEvent?.Invoke(direction);
        }

        private void FacingInputEvent() {
            bool setFacing = input.GetButton(RewiredConsts.Action.Face_Point);

            if (setFacing) {
                Vector2 mousePosition = ReInput.controllers.Mouse.screenPosition;

                onFacingInputEvent?.Invoke(mousePosition);
            }
        }
    #endregion
}
