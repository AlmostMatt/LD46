﻿// a simple struct that represents a resource and a count.
public struct ResourceAndCount
{
    public ResourceAndCount(ResourceType type, int count)
    {
        this.type = type;
        this.count = count;
    }
    public ResourceType type;
    public int count;
}