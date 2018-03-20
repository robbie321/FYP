using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

        private static Potion instance;

        public static Potion Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<Potion>();
                }

                return instance;
            }
        }
    [SerializeField]
    private int value = 0;

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }
    
}
