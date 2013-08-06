// ********************************
// <copyright file="Word.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// ********************************

namespace SampleMongoDictionary
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    /// <summary>
    /// Represents a word.
    /// </summary>
    public class Word
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Value { get; set; }

        public string Translation { get; set; }

        [BsonConstructor]
        public Word(string value, string translation)
        {
            this.Value = value;
            this.Translation = translation;
        }

        public override string ToString()
        {
            return this.Value + ": " + this.Translation;
        }
    }
}
