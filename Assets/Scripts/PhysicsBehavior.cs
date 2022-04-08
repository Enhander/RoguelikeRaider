using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhysicsBehavior : MonoBehaviour {
    #region Fields
        [Header("Inspector Injected Parameters")]
        [SerializeField]
        private float MovementSpeed;
        [SerializeField]
        private float MovementAngle;
        [SerializeField]
        private float MovementAcceleration;
        [SerializeField]
        private int CollisionSteps;
        [SerializeField]
        private float MovingDirection;
        [SerializeField]
        private float StrafingDirection;
        [SerializeField]
        private LayerMask LayerMask;

        [Header("Inspector Injected References")]
        [SerializeReference]
        protected Rigidbody2D rigidBody;
        [SerializeReference]
        protected Collider2D collider;

        [Header("Debugging Viewables")]
        [SerializeReference]
        protected PhysicsData physicsData;
        [SerializeReference]
        protected PhysicsLogic physicsLogic;
    #endregion

    #region Initialization Methods
        protected virtual void Awake() {
            physicsData = ConstructPhysicsData(MovementSpeed, MovementAngle, MovementAcceleration, MovingDirection, StrafingDirection, CollisionSteps, LayerMask);
            physicsLogic = ConstructPhysicsLogic(rigidBody, collider, physicsData);
            EventSubscribe();
        }

        protected virtual PhysicsData ConstructPhysicsData(float movementSpeed, float movementAngle, float movementAcceleration, float movingDirection, float strafingDirection, int collisionSteps, LayerMask layerMask) {
            return new PhysicsData(layerMask, movementSpeed, movementAngle, movementAcceleration, movingDirection, strafingDirection, collisionSteps);
        }

        protected abstract PhysicsLogic ConstructPhysicsLogic(Rigidbody2D rigidBody, Collider2D collider, PhysicsData physicsData);

        protected virtual void EventSubscribe() {

        }
    #endregion

    #region Cycle Methods
        protected void FixedUpdate() {
            physicsLogic.OnPhysicsUpdate();
        }
    #endregion
}
