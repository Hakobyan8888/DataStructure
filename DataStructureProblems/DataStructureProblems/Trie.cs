using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataStructureProblems
{
    public class TrieNode
    {
        public string Prefix { get; set; }
        public Dictionary<char, TrieNode> Children { get; set; }
        public bool IsWord;
        public TrieNode(string prefix)
        {
            this.Prefix = prefix;
            this.Children = new Dictionary<char, TrieNode>();
        }
    }
    public class Trie
    {
        public TrieNode root;
        public int CountNode = 1;
        public Trie()
        {
            root = new TrieNode("");
        }
        public void InsertWord(string s)
        {
            var current = root;
            for (int i = 0; i < s.Length; i++)
            {
                if (!current.Children.ContainsKey(s[i]))
                {
                    current.Children.Add(s[i], new TrieNode(s.Substring(0, i + 1)));
                    CountNode++;
                }
                current = current.Children[s[i]];
                if (i == s.Length - 1)
                    current.IsWord = true;
            }
        }

        List<string> results = new List<string>();

        public List<string> GetWordsForPrefix(string pre)
        {
            results.Clear();

            var current = root;
            foreach (var c in pre)
            {
                if (current.Children.ContainsKey(c))
                    current = current.Children[c];
                else
                    return results;
            }
            FindAllChildWords(current, results);
            return results;
        }
        private void FindAllChildWords(TrieNode node, List<string> results)
        {
            if (node.IsWord)
                results.Add(node.Prefix);
            foreach (var c in node.Children.Keys)
            {
                FindAllChildWords(node.Children[c], results);
            }
        }
        public bool Search(string key)
        {
            var current = root;
            foreach (var k in key)
            {
                if (current.Children[k] == null)
                    return false;
                current = current.Children[k];
            }
            return current != null && current.IsWord;
        }
        //public void SearchPrefix(string word, int cost)
        //{
        //    var node = root;
        //    foreach (var index in word.Select(t => t - 'a'))
        //    {
        //        if (node.children[index] == null) return;
        //        node = node.children[index];
        //        if (!node.isEndOfWord) continue;
        //        node.words.Add(Tuple.Create(-cost, word));
        //        if (node.words.Count > 12)
        //            node.words.Remove(node.words.Last());
        //    }
        //}
    }
}