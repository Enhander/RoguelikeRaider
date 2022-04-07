using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public abstract class InputLogic : MonoBehaviour {
    #region Fields
        [Header("Injected Parameters")]
        [SerializeField]
        protected int inputID;

        [Header("Debugging Viewables")]
        [SerializeReference]
        protected Rewired.Player input;
    #endregion

    #region Initialization Methods
        protected void Awake() {
            InitializeInput(inputID);
        }

        protected void InitializeInput(int inputID) {
            input = ReInput.players.GetPlayer(inputID);
        }
    #endregion

    #region Event Methods
        protected void Update() {
            FireInputEvents();
        }

        protected abstract void FireInputEvents();
    #endregion
}
