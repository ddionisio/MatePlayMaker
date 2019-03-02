﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using M8;

namespace HutongGames.PlayMaker.Actions.M8 {
    [System.Serializable]
    public class FsmLocalize {
        public enum FromType {
            Localize,
            StringRef
        }

        public FromType from = FromType.Localize;
        public FsmString stringRef = new FsmString();

        public string GetString() {
            switch(from) {
                case FromType.StringRef:
                    return stringRef.Value;
                default:
                    return Localize.Get(stringRef.Value);
            }
        }
    }
}