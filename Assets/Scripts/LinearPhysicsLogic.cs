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
            Vector2 totalVelocity = CalculateMovingVelocity(physicsData) + CalculateStrafingVelocity(physicsData);
            totalVelocity = totalVelocity.normalized * physicsData.MovementSpeed * Time.deltaTime;
            return totalVelocity;
        }

        private Vector2 CalculateMovingVelocity(PhysicsData physicsData) {
            float xMovingVelocity = Mathf.Cos(physicsData.MovementAngle * Mathf.Deg2Rad) * physicsData.MovingDirection;
            float yMovingVelocity = Mathf.Sin(physicsData.MovementAngle * Mathf.Deg2Rad) * physicsData.MovingDirection;
            Vector2 movingVelocity = new Vector2(xMovingVelocity, yMovingVelocity);
            return movingVelocity.normalized;
        }

        private Vector2 CalculateStrafingVelocity(PhysicsData physicsData) {
            float strafingAngle = physicsData.MovementAngle - 90f;
            float xStrafingVelocity = Mathf.Cos(strafingAngle * Mathf.Deg2Rad) * physicsData.StrafingDirection;
            float yStrafingVelocity = Mathf.Sin(strafingAngle * Mathf.Deg2Rad) * physicsData.StrafingDirection;
            Vector2 strafingVelocity = new Vector2(xStrafingVelocity, yStrafingVelocity);
            return strafingVelocity.normalized;
        }

        private void ApplyAcceleration(PhysicsData physicsData) {
            physicsData.MovementSpeed += physicsData.MovementAcceleration * Time.deltaTime;
        }
    #endregion
}
