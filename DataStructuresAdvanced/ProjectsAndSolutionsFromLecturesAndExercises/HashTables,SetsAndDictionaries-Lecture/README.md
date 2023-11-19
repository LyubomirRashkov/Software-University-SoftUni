## PROBLEMS DESCRIPTION - HASH TABLES, SETS AND DICTIONARIES (Lecture)


### Problem 1. Hash Table with Chaining

You must implement a hash table that uses chaining in a linked list as collision resolution strategy. The hash table will hold its elements (key-value pairs) in a class KeyValue\<TKey, TValue\>. The hash table will consist of slots, each holding a linked list of key-value pairs: LinkedList\<KeyValue\<TKey, TValue\>\>.