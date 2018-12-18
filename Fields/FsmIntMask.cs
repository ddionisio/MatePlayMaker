using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.M8 {
    [System.Serializable]
    public class FsmIntMask {
        public FsmInt fsmInt = 0;
        public int iValue { get { return fsmInt.Value; } set { fsmInt = value; } }
        public uint uValue { get { return (uint)fsmInt.Value; } set { fsmInt = (int)value; } }
    }
}