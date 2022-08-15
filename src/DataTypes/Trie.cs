using System.Text;

namespace LeetCode.DataTypes;

public class TrieNode
{
    private const int R = 26;
    
    private readonly TrieNode[] _links;
    
    public TrieNode()
    {
        _links = new TrieNode[R];
    }
    
    public int LinksCount { get; private set; }

    public bool IsTerminal => LinksCount == 0;

    public bool ContainsKey(char ch)
    {
        return _links[ch - 'a'] != null;
    }

    public TrieNode Get(char ch)
    {
        return _links[ch - 'a'];
    }

    public void Put(char ch)
    {
        _links[ch - 'a'] = new TrieNode();
        LinksCount++;
    }
}

public class Trie
{
    private readonly TrieNode _root;

    public Trie()
    {
        _root = new TrieNode();
    }

    public void Insert(string word)
    {
        var node = _root;

        foreach (var ch in word)
        {
            if (!node.ContainsKey(ch))
            {
                node.Put(ch);
            }

            node = node.Get(ch);
        }
    }

    private TrieNode SearchPrefix(string word)
    {
        var node = _root;

        foreach (var ch in word)
        {
            if (node.ContainsKey(ch))
            {
                node = node.Get(ch);
            }
            else
            {
                return null;
            }
        }

        return node;
    }

    public bool Search(string word)
    {
        var node = SearchPrefix(word);
        return node != null && node.IsTerminal;
    }
    
    public bool StartsWith(string word)
    {
        var node = SearchPrefix(word);
        return node != null;
    }

    public string SearchLongestPrefix(string word)
    {
        var node = _root;
        
        var prefix = new StringBuilder();

        foreach (var ch in word)
        {
            if (node.ContainsKey(ch) && node.LinksCount == 1 && !node.IsTerminal)
            {
                prefix.Append(ch);
                node = node.Get(ch);
            }
            else
            {
                return prefix.ToString();
            }
        }

        return prefix.ToString();
    }
}