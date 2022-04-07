using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LinearPhysicsLogic : PhysicsLogic {
    #region Fields
        [Header("Debugging Viewables")]
        [SerializeField]
        private Vector2 velocity;
    #endregion

    #region Initialization Methods
        public LinearPhysicsLogic(Rigidbody2D rigidBody, Collider2D collider, PhysicsData physicsData) : base(rigidBody, collider, physicsData) {

        }
    #endregion

    #region Function Methods
        public override void OnPhysicsUpdate() {
            Move();
        }

        private void Move() {
            velocity = CalculateVelocity(physicsData);
            ForecastCollisions(rigidBody, collider, physicsData, velocity, physicsData.CollisionSteps);
            ApplyAcceleration(physicsData);
        }

        private Vector2 CalculateVelocity(PhysicsData physicsData) {
            float xVelocity = Mathf.Cos(physicsData.MovementAngle * Mathf.Deg2Rad) * physicsData.MovementSpeed * Time.deltaTime;
            float yVelocity = Mathf.Sin(physicsData.MovementAngle * Mathf.Deg2Rad) * physicsData.MovementSpeed * Time.deltaTime;
            return new Vector2(xVelocity, yVelocity);
        }

        private void ApplyAcceleration(PhysicsData physicsData) {
            physicsData.MovementSpeed += physicsData.MovementAcceleration * Time.deltaTime;
        }
    #endregion
}
