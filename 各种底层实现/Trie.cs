using System;
using System.Collections.Generic;

namespace ConsoleApp7 {
    class Trie {
        private class Node {
            public bool isWord;
            public Dictionary<char, Node> next;
            public Node(bool isWord) {
                this.isWord = isWord;
                next = new Dictionary<char, Node>();
            }
            public Node() : this(false) { }
        }
        private Node root;
        private int size;
        public Trie() {
            root = new Node();
            size = 0;
        }
        //获得Trie中存储的单词数量
        public int GetSize() {
            return size;
        }
        //向Trie中添加一个新的单词
        public void AddWord(string word) {
            Node cur = root;
            for (int i = 0; i < word.Length; i++) {
                char c = word[i];
                if (!cur.next.ContainsKey(c)) {
                    cur.next.Add(c, new Node());
                }
                cur = cur.next[c];
            }
            if (!cur.isWord) {
                cur.isWord = true;
                size++;
            }
        }
        //查询单词是否在Trie中
        public bool ContainsWord(string word) {
            Node cur = root;
            for (int i = 0; i < word.Length; i++) {
                char c = word[i];
                if (!cur.next.ContainsKey(c)) {
                    return false;
                }
                cur = cur.next[c];
            }
            return cur.isWord;
        }
        //查询Trie中是否有单词以prefix为前缀
        public bool IsPrefix(string prefix) {
            Node cur = root;
            for (int i = 0; i < prefix.Length; i++) {
                char c = prefix[i];
                if (!cur.next.ContainsKey(c)) {
                    return false;
                }
                cur = cur.next[c];
            }
            return true;
        }
        //搜索单词，
        //addWord("bad")
        //addWord("dad")
        //addWord("mad")
        //search("pad") -> false
        //search("bad") -> true
        //search(".ad") -> true
        //search("b..") -> true
        public bool Search(string word) {
            return Match(root, word, 0);
        }
        //从根节点开始，搜索word，从word的第0个元素开始搜索
        private bool Match(Node node, string word, int index) {
            if (index == word.Length) {
                return node.isWord;
            }
            char c = word[index];
            if (c != '.') {
                if (!node.next.ContainsKey(c)) {
                    return false;
                }
                return Match(node.next[c], word, index + 1);
            }
            else {
                foreach (var nextchar in node.next.Keys) {
                    if (Match(node.next[nextchar], word, index + 1)) {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}













