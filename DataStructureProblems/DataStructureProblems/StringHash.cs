using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureProblems
{
    public static class StringHash
    {
        const int p = 31;
        static ulong[] Hashes;
        static ulong[] Powers;

        public static ulong[] CreateAllHashes(string s)
        {
            Hashes = new ulong[s.Length];
            Powers = new ulong[s.Length];
            Hashes[0] = s[0];
            Powers[0] = 1;
            for (int i = 1; i < s.Length; i++)
            {
                Hashes[i] = Hashes[i - 1] * p + s[i];
                Powers[i] = Powers[i - 1] * p;
            }
            return Hashes;
        }

        public static Tuple<ulong[], ulong[]> CreateAllHashesAndPowers(string s)
        {
            Hashes = new ulong[s.Length];
            Powers = new ulong[s.Length];
            Hashes[0] = s[0];
            Powers[0] = 1;
            for (int i = 1; i < s.Length; i++)
            {
                Hashes[i] = Hashes[i - 1] * p + s[i];
                Powers[i] = Powers[i - 1] * p;
            }
            return Tuple.Create(Hashes, Powers);
        }

        public static ulong GetSubstringHash(int start, int end, ulong[] hashes, ulong[] powers)
        {
            int leng = end - start + 1;
            if (leng == powers.Length)
            {
                leng--;
            }
            return hashes[end] - (start == 0 ? 0 : hashes[start - 1]) * powers[leng];
        }

    }


    public struct StringHashStruct
    {
        const int p = 31;
        static ulong[] Hashes;
        static ulong[] Powers;

        public StringHashStruct(string s)
        {
            Hashes = new ulong[s.Length];
            Powers = new ulong[s.Length];
            Hashes[0] = s[0];
            Powers[0] = 1;
            for (int i = 1; i < s.Length; i++)
            {
                Hashes[i] = Hashes[i - 1] * p + s[i];
                Powers[i] = Powers[i - 1] * p;
            }
        }

        public static ulong[] CreateAllHashes(string s)
        {
            Hashes = new ulong[s.Length];
            Powers = new ulong[s.Length];
            Hashes[0] = s[0];
            Powers[0] = 1;
            for (int i = 1; i < s.Length; i++)
            {
                Hashes[i] = Hashes[i - 1] * p + s[i];
                Powers[i] = Powers[i - 1] * p;
            }
            return Hashes;
        }

        public ulong GetSubstringHash(int start, int end)
        {
            int leng = end - start + 1;
            if (leng == Powers.Length)
            {
                leng--;
            }
            return Hashes[end] - (start == 0 ? 0 : Hashes[start - 1]) * Powers[leng];
        }
    }

}
