using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsBehavior : PhysicsBehavior {
    #region Fields
        [SerializeReference]
        protected PlayerMovementInputLogic playerMovementInputLogic;
    #endregion

    #region Initialization Methods
        protected override PhysicsLogic ConstructPhysicsLogic(Rigidbody2D rigidBody, Collider2D collider, PhysicsData physicsData) {
            return new LinearPhysicsLogic(rigidBody, collider, physicsData);
        }

        protected override void EventSubscribe() {
            base.EventSubscribe();

            playerMovementInputLogic.onMoveInputEvent += OnMoveInput;
            playerMovementInputLogic.onStrafeInputEvent += OnStrafeInput;
            playerMovementInputLogic.onFacingInputEvent += OnFacingInput;
        }
    #endregion

    #region Event Methods
        protected void OnMoveInput(float direction) {
            ApplyMovement(direction);
        }

        protected void ApplyMovement(float direction) {
            physicsData.MovingDirection = direction;
        }

        protected void OnStrafeInput(float direction) {
            ApplyStrafe(direction);
        }

        protected void ApplyStrafe(float direction) {
            physicsData.StrafingDirection = direction;
        }

        protected void OnFacingInput(Vector2 mousePosition) {
            ApplyFacing(mousePosition);
        }

        protected void ApplyFacing(Vector2 mousePosition) {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector2 playerPosition = rigidBody.position;
            float facingAngle = Mathf.Atan2(mouseWorldPosition.y - playerPosition.y, mouseWorldPosition.x - playerPosition.x) * Mathf.Rad2Deg;

            physicsData.MovementAngle = facingAngle;
        }
    #endregion
}
