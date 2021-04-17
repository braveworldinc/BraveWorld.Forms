using System;
using System.Collections.Generic;
using System.Text;

namespace BraveWorld.Forms.Classes
{
    public abstract class Singleton<T> where T : class
    {
        private static T _instance = null;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = default(T);

                return _instance;
            }
        }
    }
}
