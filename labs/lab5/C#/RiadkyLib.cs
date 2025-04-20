using System;

namespace RiadkyLib {
    public abstract class Riadky {
        protected string str;
        public Riadky(string s) {
            str = s;
        }
        public abstract int GetLength();
        public abstract string InsertChar();
    }

    public class VelykiLitery : Riadky {
        public VelykiLitery(string s) : base(s) { }
        public override int GetLength() => str.Length;
        public override string InsertChar() {
            string res = "";
            foreach (char c in str) {
                res += c;
                res += '/';
            }
            return res;
        }
    }

    public class MaliLitery : Riadky {
        public MaliLitery(string s) : base(s) { }
        public override int GetLength() => str.Length;
        public override string InsertChar() {
            string res = "";
            foreach (char c in str) {
                res += c;
                res += '\\';
            }
            return res;
        }
    }
}
