using System;
using System.Collections.Generic;

namespace LikeSystem
{
    public static class Like
    {
        public static string DisplayLikes(List<string> likes)
        {
            return (likes?.Count ?? 0) switch
            {
                0 => "no one likes this",
                1 => $"{likes[0]} likes this",
                2 => $"{likes[0]} and {likes[1]} like this",
                3 => $"{likes[0]}, {likes[1]} and {likes[2]} like this",
                _ => $"{likes[0]}, {likes[1]} and {likes.Count - 2} others like this",
            };
        }
    }
}