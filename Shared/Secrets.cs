﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using VereinsfliegerTester;
//
//    var secrets = Secrets.FromJson(jsonString);

namespace Vereinsflieger.Shared
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Secrets
    {
        [JsonProperty("appKey", Required = Required.Always)]
        public string AppKey { get; set; }

        [JsonProperty("username", Required = Required.Always)]
        public string Username { get; set; }

        [JsonProperty("password", Required = Required.Always)]
        public string Password { get; set; }
    }

    public partial class Secrets
    {
        public static Secrets FromJson(string json) => JsonConvert.DeserializeObject<Secrets>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Secrets self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
