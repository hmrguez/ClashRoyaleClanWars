﻿namespace ClashRoyaleClanWarsAPI.Domain.Exceptions;

public class DuplicationIdException : Exception
{
    public DuplicationIdException() : base("Index already exists. You are trying to add an existing index") { }

    public DuplicationIdException(params int[] ids) : base("Ids " + String.Join(",", ids) + " already exist. You are trying to add an existing key") { }
}
