using System;

namespace IntrinsicsDude.Tools {

    public static partial class IntrinsicTools {


        /// <summary>
        /// Return the first mnemonic before the provided position in the provided line
        /// </summary>
        public static Tuple<Intrinsic, int> getPreviousKeywordPos(int pos, string line)
        {
            //Debug.WriteLine(string.Format("INFO: getKeyword; pos={0}; line=\"{1}\"", pos, new string(line)));
            if ((pos < 0) || (pos >= line.Length))
            {
                return new Tuple<Intrinsic, int>(Intrinsic.NONE, pos);
            }
            string line2 = line.ToUpper();

            // find the beginning of the keyword
            for (int i1 = pos - 1; i1 >= 2; --i1)
            {
                char c0 = line2[i1 - 0];
                if (c0.Equals('_'))
                {
                    char c1 = line2[i1 - 1];
                    char c2 = line2[i1 - 2];

                    if (c1.Equals('M') && c2.Equals('M'))
                    {
                        for (int i2 = i1 + 2; i2 < line.Length; ++i2)
                        {
                            char c3 = line2[i2];
                            if (Char.IsWhiteSpace(c3) || c3.Equals('('))
                            {
                                int endPos = i2 - 1;
                                Intrinsic intrinsic = IntrinsicTools.parseIntrinsic(line2.Substring(i1, endPos));
                                if (intrinsic != Intrinsic.NONE)
                                {
                                    return new Tuple<Intrinsic, int>(intrinsic, i1);
                                }
                            }
                        }
                    }
                }
            }
            return new Tuple<Intrinsic, int>(Intrinsic.NONE, pos);
        }
    }
}
