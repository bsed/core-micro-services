﻿namespace Common.Options
{
    public class RedisOptions : ISettingOptions
    {
        public string host { get; set; }
        public string name { get; set; }
        public int port { get; set; }

        public static string GetConfigName => "redis";
    }
}
