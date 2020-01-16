using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GenerateResourceDictionaryFromResx
{
   public class FallbackDictionaryWithDefaultKey<TKey, TValue> : IDictionary<TKey, TValue>
   {
      private IDictionary<TKey, TValue> _store = new Dictionary<TKey, TValue>();

      private Func<TKey> _defaultKeyProvider;
      private Func<TKey> _fallbackKeyProvider;
      public FallbackDictionaryWithDefaultKey() { _defaultKeyProvider = () => _defaultKey; _fallbackKeyProvider = () => _fallbackKey; }
      public FallbackDictionaryWithDefaultKey( Func<TKey> defaultKeyProvider, Func<TKey> fallbackKeyProiver )
      {
         _defaultKeyProvider = defaultKeyProvider;
         _fallbackKeyProvider = fallbackKeyProiver;
      }

      private TKey _defaultKey;
      private TKey _fallbackKey;
      /// <summary>
      /// The key to the item in the dictionary that will be returned when the dictionary is converted to TValue.
      /// If this value is not set the item with a key of default(TKey) will be considered the "default".
      /// When TKey is a reference type, null is a valid key.
      /// </summary>
      public virtual TKey DefaultKey
      {
         private get => _defaultKey = _defaultKeyProvider();
         set { _defaultKey = value; }
      }
      /// <summary>
      /// The key to the item in the dictionary that will be returned when the dictionary does not contain the requested key but does contain a value for the fallback key.
      /// <see cref="this[TKey]"/>
      /// If this value is not set the item with a key of default(TKey) will be considered the "default".
      /// When TKey is a reference type, null is a valid key.
      /// </summary>
      public virtual TKey FallbackKey
      {
         private get
         {
            return ( _fallbackKey = _fallbackKeyProvider() );
         }
         set => _fallbackKey = value;
      }

      /// <summary>
      /// Returns a value for the key
      /// If the key does not exist, DefaultKey is attempted
      /// If neither key nor DefaultKey exist, FallbackKey is attempted
      /// </summary>
      /// <param name="key">the key to the item in the dictionary</param>
      /// <returns>returns the value stored for the <typeparamref name="TKey"/> key in this dictionary </returns>
      public virtual TValue this[TKey key]
      {
         get
         {
            TValue value;
            if ( _store.TryGetValue( key, out value ) )
            {
               return value ?? _store[key];
            }
            if ( _store.TryGetValue( DefaultKey, out value ) )
            {
               return value ?? _store[key];
            }
            if ( _store.TryGetValue( FallbackKey, out value ) )
            {
               return value ?? _store[key];
            }
            return _store[key];
         }
         set
         {
            _store[key] = value;
         }
      }

      /// <summary>
      /// Writes the string representation of the value stored for the default key.
      /// </summary>
      /// <returns> A <seealso cref="System.String"/> resulting from calling 
      /// <typeparamref name="TValue"/>.ToString() on the value stored at 
      /// <see cref="DefaultKey"/> in this dictionary. 
      /// </returns>
      public override string ToString() => this[DefaultKey].ToString();
      public static implicit operator TValue( FallbackDictionaryWithDefaultKey<TKey, TValue> dictionary ) => dictionary[dictionary.DefaultKey];

      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public bool TryGetValue( TKey key, out TValue value ) => _store.TryGetValue( key, out value );
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public ICollection<TKey> Keys => _store.Keys;
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public ICollection<TValue> Values => _store.Values;
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public int Count => _store.Count;
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public bool IsReadOnly => ( _store as IDictionary<TKey, TValue> ).IsReadOnly;
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public void Add( TKey key, TValue value ) => ( (IDictionary<TKey, TValue>)_store ).Add( key, value );
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public void Add( KeyValuePair<TKey, TValue> item ) => ( (IDictionary<TKey, TValue>)_store ).Add( item );
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public void Clear() => ( (IDictionary<TKey, TValue>)_store ).Clear();
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public bool Contains( KeyValuePair<TKey, TValue> item ) => ( (IDictionary<TKey, TValue>)_store ).Contains( item );
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public bool ContainsKey( TKey key ) => ( (IDictionary<TKey, TValue>)_store ).ContainsKey( key );
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public void CopyTo( KeyValuePair<TKey, TValue>[] array, int arrayIndex ) => ( (IDictionary<TKey, TValue>)_store ).CopyTo( array, arrayIndex );
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => ( (IDictionary<TKey, TValue>)_store ).GetEnumerator();
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public bool Remove( TKey key ) => ( (IDictionary<TKey, TValue>)_store ).Remove( key );
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      public bool Remove( KeyValuePair<TKey, TValue> item ) => ( (IDictionary<TKey, TValue>)_store ).Remove( item );
      [ExcludeFromCodeCoverage /*Simply consuming built in dictionary functionality*/]
      IEnumerator IEnumerable.GetEnumerator() => ( (IDictionary<TKey, TValue>)_store ).GetEnumerator();
   }
}