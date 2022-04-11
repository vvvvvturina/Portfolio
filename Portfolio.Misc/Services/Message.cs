﻿using MimeKit;

namespace Portfolio.Misc.Services;

public class Message
{
    public string Receiver { get; set; }
    public string Header  { get; set; }
    public string Content  { get; set; }
    public MimeMessage MimeMessage { get; set; }

    public Message(string header, string content)
    {
        Header = header;
        Content = content;
        MimeMessage = CreateMessage(Header, CreateBody(Content));
    }
    
    public MimeMessage CreateMessage(string header, MimeEntity bodyEntity)
    {
        MimeMessage message = new MimeMessage();
        message.From.Add(new MailboxAddress("отправитель", "whoomipark@gmail.com" ));
        message.To.Add(new MailboxAddress("получатель", "tyurina.vladislava@gmail.com"));
        message.Subject = header;
        message.Body = bodyEntity;
        return message;
    }

    public MimeEntity CreateBody(string bodyText)
    {
        var temp = new BodyBuilder();
        temp.HtmlBody = $"<div style=\"color: black;\">{bodyText}</div>";
        return temp.ToMessageBody();
    }
}