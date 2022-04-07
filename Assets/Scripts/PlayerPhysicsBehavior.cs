using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsBehavior : PhysicsBehavior {
    #region Initialization Methods
    protected override PhysicsLogic ConstructPhysicsLogic(Rigidbody2D rigidBody, Collider2D collider, PhysicsData physicsData) {
        return new LinearPhysicsLogic(rigidBody, collider, physicsData);
    }
    #endregion
}
