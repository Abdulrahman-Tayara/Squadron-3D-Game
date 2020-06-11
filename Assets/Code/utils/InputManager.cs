using Assets.Code.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.utils {
    public class InputManager {

        private static ICahceProvider cahce = Injector.injectCahceProvider();

        public static void changeKey(Key key, KeyCode newKey) {
            cahce.putInt(key.ToString(), (int) newKey);
        }

        public static KeyCode geyKey(Key key) {
            int keyInt = cahce.getInt(key.ToString(), (int) key);
            return (KeyCode) keyInt;
        }
    }
    public enum Key {
        SPECIAL_FIRE = (int) KeyCode.Mouse0,
        BASIC_FIRE = (int) KeyCode.Mouse1,
        BOOST = (int) KeyCode.LeftShift,

    }
}


