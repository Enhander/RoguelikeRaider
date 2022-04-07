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
        private LayerMask LayerMask;

        [Header("Inspector Injected References")]
        [SerializeReference]
        private Rigidbody2D rigidBody;
        [SerializeReference]
        private Collider2D collider;

        [Header("Debugging Viewables")]
        [SerializeReference]
        private PhysicsData physicsData;
        [SerializeReference]
        private PhysicsLogic physicsLogic;
    #endregion

    #region Initialization Methods
    protected virtual void Awake() {
        physicsData = ConstructPhysicsData(MovementSpeed, MovementAngle, MovementAcceleration, CollisionSteps, LayerMask);
        physicsLogic = ConstructPhysicsLogic(rigidBody, collider, physicsData);
    }

    protected virtual PhysicsData ConstructPhysicsData(float movementSpeed, float movementAngle, float movementAcceleration, int collisionSteps, LayerMask layerMask) {
        return new PhysicsData(layerMask, movementSpeed, movementAngle, movementAcceleration, collisionSteps);
    }

    protected abstract PhysicsLogic ConstructPhysicsLogic(Rigidbody2D rigidBody, Collider2D collider, PhysicsData physicsData);
    #endregion

    #region Cycle Methods
    protected void FixedUpdate() {
        physicsLogic.OnPhysicsUpdate();
    }
    #endregion
}
