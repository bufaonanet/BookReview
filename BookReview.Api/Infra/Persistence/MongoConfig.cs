﻿namespace BookReview.Api.Infra.Persistence;

public class MongoConfig
{
    public string ConnectionString { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
}