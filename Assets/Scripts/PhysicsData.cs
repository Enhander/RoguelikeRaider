using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PhysicsData {
    #region Fields
        [Header("Movement Parameters")]
        [SerializeField]
        private float movementSpeed;
        public float MovementSpeed {
            get { return movementSpeed; }
            set { movementSpeed = value; }
        }
        [SerializeField]
        private float movementAngle;
        public float MovementAngle {
            get { return movementAngle; }
            set { movementAngle = value; }
        }
        [SerializeField]
        private float movementAcceleration;
        public float MovementAcceleration {
            get { return movementAcceleration; }
            set { movementAcceleration = value; }
        }
        [SerializeField]
        private float movingDirection;
        public float MovingDirection {
            get { return movingDirection; }
            set { movingDirection = value; }
        }
        [SerializeField]
        private float strafingDirection;
        public float StrafingDirection {
            get { return strafingDirection; }
            set { strafingDirection = value; }
        }

        [Header("Collision Parameters")]
        [SerializeField]
        private int collisionSteps;
        public int CollisionSteps {
            get { return collisionSteps; }
        }

        private LayerMask defaultMask = LayerMask.GetMask("Default");
        [SerializeField]
        private LayerMask layerMask;
        public LayerMask LayerMask {
            get { return layerMask; }
            set { layerMask = value; }
        }
    #endregion

    #region Initialization Methods
        public PhysicsData (LayerMask layerMask, float movementSpeed = 0f, float movementAngle = 0f, float movementAcceleration = 0f, float movingDirection = 0f, float strafingDirection = 0f, int collisionSteps = 10) {
            this.layerMask = layerMask;
            this.movementSpeed = movementSpeed;
            this.movementAngle = movementAngle;
            this.movementAcceleration = movementAcceleration;
            this.movingDirection = movingDirection;
            this.strafingDirection = strafingDirection;
            this.collisionSteps = collisionSteps;
        }
    #endregion
}
