using System;
using System.Collections.Generic;
using System.Text;

namespace Composicao_2
{
    class Comment
    {
        public string Text { get; set; }

        public Comment()
        {            
        }

        public Comment(string text)
        {
            Text = text;
        }
    }

    class Post
    {
        public DateTime Moment { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        
        public Post()
        {            
        }

        public Post(DateTime moment, string title, string content, int likes)
        {
            Moment = moment;
            Title = title;
            Content = content;
            Likes = likes;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void RemoveComment(Comment comment)
        {
            Comments.Remove(comment);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(Title);
            builder.Append(Likes);
            builder.Append(" Likes - ");
            builder.AppendLine(Moment.ToString("dd/MM/YYYY HH:mm:ss"));
            builder.AppendLine(Content);
            builder.AppendLine("Comments: ");

            foreach(Comment obj in Comments){
                builder.AppendLine(obj.Text);
            }

            return builder.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Comment comment1 = new Comment("Have a nice trip!");
            Comment comment2 = new Comment("Wow that's awesome!");

            Post post1 = new Post(
                DateTime.Parse("21/06/2019 14:30:42"),
                "Traveling to New Zeland",
                "I'm going to visit this wonderful country!",
                12);

            post1.AddComment(comment1);
            post1.AddComment(comment2);
        }
    }
}