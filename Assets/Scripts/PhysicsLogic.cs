using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PhysicsLogic {
    #region Fields
        [Header("Injected References")]
        protected Rigidbody2D rigidBody;
        protected Collider2D collider;
        protected PhysicsData physicsData;

        public delegate void OnColDetected(RaycastHit2D colInfo, PhysicsData physicsData);
        public event OnColDetected colDetectedEvent;
    #endregion

    #region Initialization Methods
        public PhysicsLogic (Rigidbody2D rigidBody, Collider2D collider, PhysicsData physicsData) {
            this.rigidBody = rigidBody;
            this.collider = collider;
            this.physicsData = physicsData;
        }
    #endregion

    #region Function Methods
        public abstract void OnPhysicsUpdate();

        protected virtual void ForecastCollisions(Rigidbody2D rigidBody, Collider2D collider, PhysicsData physicsData, Vector2 velocity, float collisionSteps) {
            float forecastDistance = velocity.magnitude;
            Vector2 stepVelocity = velocity / collisionSteps;

            while (forecastDistance > 0) {
                if (CheckCollision(rigidBody, collider, physicsData, stepVelocity)) {
                    break;
                }
                else {
                    rigidBody.position += stepVelocity;
                    forecastDistance -= stepVelocity.magnitude;
                }
            }
        }

        protected virtual bool CheckCollision(Rigidbody2D rigidBody, Collider2D thisHitbox, PhysicsData physicsData, Vector2 stepVelocity) {
            Collider2D collision = Physics2D.OverlapArea((Vector2)thisHitbox.bounds.min + stepVelocity, (Vector2)thisHitbox.bounds.max + stepVelocity, physicsData.LayerMask);

            if (collision != null && collision != thisHitbox) {
                RaycastHit2D collisionInfo = Physics2D.BoxCast(rigidBody.position, rigidBody.transform.GetComponent<Collider2D>().bounds.size, 0, stepVelocity, stepVelocity.magnitude * 2, physicsData.LayerMask);

                if (collisionInfo && collisionInfo.collider != thisHitbox) {
                    colDetectedEvent?.Invoke(collisionInfo, physicsData);
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }
    #endregion

    #region Event Methods
        protected virtual void ColDetectedEvent(RaycastHit2D colInfo, PhysicsData physicsData) {
            colDetectedEvent?.Invoke(colInfo, physicsData);
        }
    #endregion
}
