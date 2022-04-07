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
        }
    #endregion

    #region Event Methods
        protected void OnMoveInput(Vector2 inputVector) {
            ApplyMovementVector(inputVector);
        }

        protected void ApplyMovementVector(Vector2 inputVector) {
            float degreeAngle = Mathf.Atan2(inputVector.y, inputVector.x) * Mathf.Rad2Deg;
            bool hasInput = inputVector.magnitude != 0;

            if (hasInput) {
                physicsData.MovementAngle = degreeAngle;
                physicsData.Moving = true;
            }
            else {
                physicsData.Moving = false;
            }
        }
    #endregion
}
